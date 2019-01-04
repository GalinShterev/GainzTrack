using GainzTrack.Infrastructure.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;

namespace GainzTrack.Infrastructure.Services
{
    public class VideoService : IVideoService
    {
        private bool IsUploadingFinished { get; set; }
        public string VideoId { get; set; }
        public VideoService()
        {
            IsUploadingFinished = false;
            VideoId = "";
        }

        public string UploadVideoToYotuube(string path)
        {
            UserCredential credential;
            using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    // This OAuth 2.0 access scope allows an application to upload files to the
                    // authenticated user's YouTube channel, but doesn't allow other types of access.
                    new[] { YouTubeService.Scope.YoutubeUpload },
                    "user",
                    CancellationToken.None
                ).Result;
            }

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = Assembly.GetExecutingAssembly().GetName().Name
            });

            var video = new Video();
            video.Snippet = new VideoSnippet();
            video.Snippet.Title = Guid.NewGuid().ToString().Substring(0,6);
            video.Status = new VideoStatus();
            video.Status.PrivacyStatus = "unlisted"; // or "private" or "public"
            var filePath = path; // Replace with path to actual movie file.

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var videosInsertRequest = youtubeService.Videos.Insert(video, "snippet,status", fileStream, "video/*");
                videosInsertRequest.ProgressChanged += videosInsertRequest_ProgressChanged;
                videosInsertRequest.ResponseReceived += videosInsertRequest_ResponseReceived;
                videosInsertRequest.Upload();
                
            }

            if (IsUploadingFinished)
                return VideoId;

            throw new InvalidOperationException("Couldn't upload video");
        }
        void videosInsertRequest_ProgressChanged(Google.Apis.Upload.IUploadProgress progress)
        {
            switch (progress.Status)
            {
                case UploadStatus.Completed:
                    IsUploadingFinished = true;
                    break;
                case UploadStatus.Failed:
                    throw new InvalidOperationException("An error prevented the upload from completing.\n{0}", progress.Exception);

            }
        }

        void videosInsertRequest_ResponseReceived(Video video)
        {
            VideoId = video.Id;
            Console.WriteLine("Video id '{0}' was successfully uploaded.", video.Id);
        }

    }
}
