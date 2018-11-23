using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Entities
{
    public class WorkoutRoutine : BaseEntity
    {
        public WorkoutRoutine()
        {
            this.WorkoutDays = new HashSet<WorkoutDay>();
            this.TimesCopied = new HashSet<CopiedWorkoutsFromUsers>();
        }

        public string Name { get; set; }
        public bool IsPublic { get; set; }

        public string CreatorId { get; set; }
        public MainUser Creator { get; set; }

        public virtual ICollection<WorkoutDay> WorkoutDays{ get; set; }
        public virtual ICollection<CopiedWorkoutsFromUsers> TimesCopied { get; set; }


    }
}
