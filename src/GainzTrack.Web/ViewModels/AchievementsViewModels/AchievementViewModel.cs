using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.ViewModels.AchievementsViewModels
{
    public class AchievementViewModel
    {
        public string ExerciseName { get; set; }
        public string Difficulty { get; set; }
        public int OverloadAmount { get; set; }
        public string OverloadType { get; set; }
        public int Points { get; set; }

    }
}
