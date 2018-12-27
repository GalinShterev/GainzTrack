using GainzTrack.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Entities
{
    public class Achievement : BaseEntity
    {
        public Achievement()
        {
            this.AchievementUsers = new HashSet<AchievementUser>();
        }

        public int AchievementPointsGain { get; set; }

        public OverloadType OverloadType { get; set; }

        public int OverloadAmount { get; set; }

        public string ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
 
        public string CreatedById { get; set; }
        public MainUser CreatedBy { get; set; }

        public virtual ICollection<AchievementUser> AchievementUsers { get; set; }


    }
}
