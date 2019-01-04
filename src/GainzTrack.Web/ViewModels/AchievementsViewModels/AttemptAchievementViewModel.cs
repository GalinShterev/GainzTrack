using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.ViewModels.AchievementsViewModels
{
    public class AttemptAchievementViewModel
    {
        public string Id { get; set; }
        public string ExerciseName { get; set; }
        public string Difficulty { get; set; }
        public int OverloadAmount { get; set; }
        public string OverloadType { get; set; }
        public int Points { get; set; }
        public IFormFile Video { get; set; }
    }
}
