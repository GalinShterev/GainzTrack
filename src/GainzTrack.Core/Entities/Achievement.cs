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

        public string Name { get; set; }
        public int AchievementPointsGain { get; set; }

        public string ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        public virtual ICollection<AchievementUser> AchievementUsers { get; set; }


    }
}
