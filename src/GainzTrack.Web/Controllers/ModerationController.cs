using GainzTrack.Core.Expressions;
using GainzTrack.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.Controllers
{
    public class ModerationController : Controller
    {
        private readonly IAchievementService _achievementService;
        public ModerationController(IAchievementService achievementService)
        {
            _achievementService = achievementService;
        }

        [Authorize(Roles = "Admin, Moderator")]
        public IActionResult Index(string section)
        {
            switch (section)
            {
                case "achievements":                   
                    return this.View("AchievementsModeration", _achievementService.ListAchievementUsers());
            }

            var achievements = _achievementService.ListAchievementUsers();
            return this.View("AchievementsModeration", achievements);
        }
        public IActionResult GetAchievementUserModal(string achievementUserId)
        {
            var model = _achievementService.GetAchievementUserById(achievementUserId);

            return this.View(model);
        }
    }
}
