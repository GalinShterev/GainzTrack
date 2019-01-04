using GainzTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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

        public string Username { get; set; }

        public string IdentityUserId { get; set; }

        [NotMapped]
        public int AchievementPoints => this.AchievementUsers.Where(x => x.IsApproved == true).Sum(x => x.Achievement.AchievementPointsGain);

        public string TitleId { get; set; }
        public Title Title { get; set; }

        public virtual ICollection<WorkoutRoutine> WorkoutRoutines { get; set; }
        public virtual ICollection<AchievementUser> AchievementUsers { get; set; }
        public virtual ICollection<CopiedWorkoutsFromUsers> CopiedWorkoutsFromUsers { get; set; }

    }
}
