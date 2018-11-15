using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Models
{
    public class CopiedWorkoutsFromUsers : BaseEntity
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string WorkoutRoutineId { get; set; }
        public WorkoutRoutine WorkoutRoutine { get; set; }
    }
}

