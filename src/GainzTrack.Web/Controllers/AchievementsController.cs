using GainzTrack.Core.DTOs.AchievementsDTOs;
using GainzTrack.Core.Enums;
using GainzTrack.Core.Interfaces;
using GainzTrack.Web.Extensions;
using GainzTrack.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.Controllers
{
    public class AchievementsController : Controller
    {
        private readonly IAchievementService _achievementService;
        private readonly IAchievementsViewService _achivementsViewService;
        public AchievementsController(IAchievementService achievementService,IAchievementsViewService achievementsViewService)
        {
            _achievementService = achievementService;
            _achivementsViewService = achievementsViewService;
        }

        public IActionResult Index(string filterAction)
        {
            ExerciseDifficulty difficulty;               

            var isValidDifficulty = Enum.TryParse(filterAction.Capitalize(),out difficulty);
            if(!isValidDifficulty)
                difficulty = ExerciseDifficulty.Easy | ExerciseDifficulty.Intermediate | ExerciseDifficulty.Hard;

            var filteredAchievements = _achievementService.FilterAchievements(difficulty);
            var model = _achivementsViewService.ListAchievements(filteredAchievements);

            return this.View(model);
        }

        [Authorize(Roles ="Admin")]
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
            catch(InvalidOperationException ex)
            {
                return this.BadRequest(ex.Message);
            }
            

            return Redirect("/Administration/Index");
        }
    }
}
