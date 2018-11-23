using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Entities
{
    public class WorkoutDay : BaseEntity
    {
        public WorkoutDay()
        {
            this.ExerciseWorkoutDay = new HashSet<ExerciseWorkoutDay>();
        }
        public DayOfWeek Day { get; set; }

        public string WorkoutRoutineId { get; set; }
        public WorkoutRoutine WorkoutRoutine { get; set; }

        public virtual ICollection<ExerciseWorkoutDay> ExerciseWorkoutDay { get; set; }
    }
}
