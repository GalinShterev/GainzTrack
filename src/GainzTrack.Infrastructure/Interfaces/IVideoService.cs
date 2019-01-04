using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Infrastructure.Interfaces
{
    public interface IVideoService
    {
        string UploadVideoToYotuube(string path);
    }
}
