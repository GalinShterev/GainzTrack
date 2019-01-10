using GainzTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Expressions
{
    public class WorkoutWithDaysByWorkoutNameExpression : BaseExpression<WorkoutRoutine>
    {
        public WorkoutWithDaysByWorkoutNameExpression(string workoutId, string workoutName)
            : base(b => b.Id == workoutId)
        {
            AddInclude(b => b.WorkoutDays);
            AddInclude("WorkoutDays.ExerciseWorkoutDay.Exercise");
        }
        public WorkoutWithDaysByWorkoutNameExpression(string workoutId)
           : base(b => b.Id == workoutId)
        {
            AddInclude(b => b.WorkoutDays);
            AddInclude("WorkoutDays.ExerciseWorkoutDay.Exercise");
        }
    }
}
