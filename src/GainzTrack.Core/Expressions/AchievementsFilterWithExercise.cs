using GainzTrack.Core.Entities;
using GainzTrack.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GainzTrack.Core.Expressions
{
    public class AchievementsFilterWithExercise : BaseExpression<Achievement>
    {
        public AchievementsFilterWithExercise(ExerciseDifficulty filterAction)
            :base(b=>b.Difficulty.HasFlag(filterAction))
        {
            AddInclude(b => b.Exercise);

        }
        public AchievementsFilterWithExercise()
            :base(b=>b == b)
        {
            AddInclude(b => b.Exercise);
        }
    }
}
