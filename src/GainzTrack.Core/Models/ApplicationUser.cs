using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GainzTrack.Core.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.WorkoutRoutines = new HashSet<WorkoutRoutine>();
            this.AchievementUsers = new HashSet<AchievementUser>();
        }

        public int AchievementPoints { get; set; }

        public string TitleId { get; set; }
        public Title Title { get; set; }

        public virtual ICollection<WorkoutRoutine> WorkoutRoutines { get; set; }
        public virtual ICollection<AchievementUser> AchievementUsers { get; set; }
        public virtual ICollection<CopiedWorkoutsFromUsers> CopiedWorkoutsFromUsers { get; set; }


    }
}
