using GainzTrack.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GainzTrack.Core.DTOs.AchievementsDTOs
{
    public class CreateAchievementDto
    {
        public string CreatorUsername { get; set; }
        [Required]
        public int AchievementPoints { get; set; }
        [Required]
        public string ExerciseName { get; set; }
        [Required]
        public string OverloadType { get; set; }
        [Required]
        public int OverloadAmount { get; set; }
    }
}
