using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.DTOs.AchievementsDTOs
{
    public class CreateAchievementUserDto
    {
        public string AchievementId { get; set; }
        public string Username { get; set; }
        public string VideoId { get; set; }
    }
}
