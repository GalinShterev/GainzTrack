using GainzTrack.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly IAchievementService _achievementService;
        public AdministrationController(IAchievementService achievementService)
        {
            _achievementService = achievementService;
        }
        [Authorize(Roles="Admin")]
        public IActionResult Index(string section)
        {

            switch (section)
            {
                case "achievements":
                    return this.View("AchievementsAdministration", _achievementService.ListAchievements());
                case "users":
                    return this.View("UsersAdministration");

            }

            return this.Index("achievements");
        }
    }
}
