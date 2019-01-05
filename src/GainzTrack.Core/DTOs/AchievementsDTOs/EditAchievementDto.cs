using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.DTOs.AchievementsDTOs
{
    public class EditAchievementDto
    {
        public string Id { get; set; }

        public string CreatorUsername { get; set; }

        public int AchievementPoints { get; set; }

        public string ExerciseName { get; set; }

        public string OverloadType { get; set; }

        public string Difficulty { get; set; }

        public int OverloadAmount { get; set; }
    }
}
