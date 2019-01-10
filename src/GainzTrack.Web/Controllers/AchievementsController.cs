using GainzTrack.Core.DTOs.AchievementsDTOs;
using GainzTrack.Core.Enums;
using GainzTrack.Core.Interfaces;
using GainzTrack.Infrastructure.Interfaces;
using GainzTrack.Web.Extensions;
using GainzTrack.Web.Interfaces;
using GainzTrack.Web.ViewModels;
using GainzTrack.Web.ViewModels.AchievementsViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.Controllers
{
    public class AchievementsController : Controller
    {
        private readonly IAchievementService _achievementService;
        private readonly IAchievementsViewService _achivementsViewService;
        private readonly IHostingEnvironment _environment;
        private readonly IVideoService _videoService;

        public AchievementsController(IAchievementService achievementService
                                     , IAchievementsViewService achievementsViewService
                                     , IHostingEnvironment environment
                                     , IVideoService videoService)
        {
            _achievementService = achievementService;
            _achivementsViewService = achievementsViewService;
            _environment = environment;
            _videoService = videoService;
        }
        [Authorize]
        public IActionResult Index(string filterAction)
        {
            ExerciseDifficulty difficulty;

            var isValidDifficulty = Enum.TryParse(filterAction.Capitalize(), out difficulty);
            if (!isValidDifficulty)
                difficulty = ExerciseDifficulty.Easy | ExerciseDifficulty.Intermediate | ExerciseDifficulty.Hard;

            var filteredAchievements = _achievementService.FilterAchievements(difficulty);

            var model = _achivementsViewService.ListAchievements(filteredAchievements);

            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(string achievementId)
        {
            var model = _achivementsViewService.GetEditAchievementDto(achievementId);
            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(EditAchievementDto dto)
        {
            _achievementService.EditAchievement(dto);
            return Redirect("/Administration/Index");
        }

            
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(CreateAchievementDto dto)
        {
            if (!this.ModelState.IsValid)
                return this.View(dto);

            dto.CreatorUsername = this.User.Identity.Name;

            try
            {
                var entity = _achievementService.CreateAchievement(dto);
            }
            catch (InvalidOperationException ex)
            {
                return this.BadRequest(ex.Message);
            }


            return Redirect("/Administration/Index");
        }

        [Authorize]
        public IActionResult Attempt(string id)
        {
            var model = _achivementsViewService.GetAchievementAttempt(id);
            return this.View(model);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Attempt(AttemptAchievementViewModel viewModel)
        {
            if (viewModel.Video == null)
                return this.View("Error",new ErrorViewModel {Message = "Invalid file" });

            try
            {
                var uploadDir = Path.Combine(_environment.WebRootPath, "Videos");
                var filePath = Path.Combine(uploadDir, viewModel.Video.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    viewModel.Video.CopyTo(stream);
                }

                var uploadedVideoId = _videoService.UploadVideoToYotuube(filePath);
                

                Task.Run(() => System.IO.File.Delete(filePath));


                var achievementUserDto = _achivementsViewService.GetAchievementUserDto(this.User.Identity.Name,
                                                                                       uploadedVideoId,
                                                                                        viewModel.Id);


                _achievementService.CreateAchievementUser(achievementUserDto);
                               
                return Redirect("/Achievements/Index");
            }
            catch (InvalidOperationException ex)
            {
                return this.View("Error", new ErrorViewModel { Message = ex.Message });
            }
        }
        [Authorize(Roles ="Admin,Moderator")]
        public IActionResult ApproveAchievement(string achievementUserId)
        {

            var achievement = _achievementService.GetAchievementUserById(achievementUserId);

            _achievementService.ApproveAchievement(achievement);

            return Ok();
        }

        [Authorize(Roles = "Admin,Moderator")]
        public IActionResult DenyAchievement(string achievementUserId)
        {

            var achievement = _achievementService.GetAchievementUserById(achievementUserId);

            _achievementService.DenyAchievement(achievement);

            return Ok();
        }
    }
}
