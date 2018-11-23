using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Entities
{
    public class ExerciseWorkoutDay : BaseEntity
    {
        public string ExerciseId { get; set; }
        public Exercise Exercise { get; set; }

        public string WorkoutDayId { get; set; }
        public WorkoutDay WorkoutDay { get; set; }
    }
}
