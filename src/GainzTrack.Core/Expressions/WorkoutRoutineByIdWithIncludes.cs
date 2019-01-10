using GainzTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Expressions
{
    public class WorkoutRoutineByIdWithIncludes : BaseExpression<WorkoutRoutine>
    {
        public WorkoutRoutineByIdWithIncludes(string id)
            :base(b=>b.Id == id)
        {
            AddInclude(b => b.Creator);
            AddInclude(b => b.WorkoutDays);
            AddInclude("WorkoutDays.ExerciseWorkoutDay.Exercise");
            AddInclude(b => b.TimesCopied);
            AddInclude("Creator.AchievementUsers.Achievement");
        }
        public WorkoutRoutineByIdWithIncludes()
        : base(b => b == b)
        {
            AddInclude(b => b.Creator);
            AddInclude(b => b.WorkoutDays);
            AddInclude("WorkoutDays.ExerciseWorkoutDay.Exercise");
            AddInclude(b => b.TimesCopied);
            AddInclude("Creator.AchievementUsers.Achievement");
        }
    }
}
