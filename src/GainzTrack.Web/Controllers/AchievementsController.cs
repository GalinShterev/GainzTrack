using GainzTrack.Core.DTOs.AchievementsDTOs;
using GainzTrack.Core.Interfaces;
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
        public AchievementsController(IAchievementService achievementService)
        {
            _achievementService = achievementService;
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
            catch(Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
            

            return Redirect("/Administration/Index");
        }
    }
}
