using GainzTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Expressions
{
    public class WorkoutDaysByWorkoutRoutine : BaseExpression<WorkoutDay>
    {
        public WorkoutDaysByWorkoutRoutine(string workoutRoutineId)
            :base(b=>b.WorkoutRoutineId == workoutRoutineId)
        {

        }
    }
}
