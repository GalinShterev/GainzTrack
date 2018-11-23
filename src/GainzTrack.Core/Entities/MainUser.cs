using GainzTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Entities
{
    public class MainUser : BaseEntity
    {
        public MainUser()
        {
            this.WorkoutRoutines = new HashSet<WorkoutRoutine>();
            this.AchievementUsers = new HashSet<AchievementUser>();
        }

        public string IdentityUserId { get; set; }

        public int AchievementPoints { get; set; }

        public string TitleId { get; set; }
        public Title Title { get; set; }

        public virtual ICollection<WorkoutRoutine> WorkoutRoutines { get; set; }
        public virtual ICollection<AchievementUser> AchievementUsers { get; set; }
        public virtual ICollection<CopiedWorkoutsFromUsers> CopiedWorkoutsFromUsers { get; set; }

    }
}
