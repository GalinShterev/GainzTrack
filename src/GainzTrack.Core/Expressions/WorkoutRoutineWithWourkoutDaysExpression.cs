using GainzTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Expressions
{
    public class WorkoutRoutineWithWourkoutDaysExpression : BaseExpression<WorkoutRoutine>
    {
        public WorkoutRoutineWithWourkoutDaysExpression(string userId)
            :base(b=>b.CreatorId == userId)
        {
            AddInclude(b => b.WorkoutDays);
            AddInclude("WorkoutDays.ExerciseWorkoutDay.Exercise");
        }
        public WorkoutRoutineWithWourkoutDaysExpression(string userId,string workoutName)
            : base(b => b.CreatorId == userId && b.Name == workoutName)
        {
            AddInclude(b => b.WorkoutDays);
            AddInclude("WorkoutDays.ExerciseWorkoutDay.Exercise");
            AddInclude(b => b.Creator);
        }

        //public WorkoutRoutineWithWourkoutDaysExpression(string workoutId,string workoutName)
        //    : base(b => b.Id == workoutId)
        //{
        //    AddInclude(b => b.WorkoutDays);
        //    AddInclude("WorkoutDays.ExerciseWorkoutDay.Exercise");
        //}
        
    }
}
