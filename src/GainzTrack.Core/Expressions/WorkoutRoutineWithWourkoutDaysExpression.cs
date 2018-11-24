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
        }
    }
}
