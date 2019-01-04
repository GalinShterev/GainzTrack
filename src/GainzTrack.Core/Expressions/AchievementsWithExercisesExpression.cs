﻿using GainzTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Expressions
{
    public class AchievementsWithExercisesExpression : BaseExpression<Achievement>
    {
        public AchievementsWithExercisesExpression(string achievementId)
            :base(b=>b.Id == achievementId)
        {
            AddInclude(b => b.Exercise);
        }
        public AchievementsWithExercisesExpression()
            :base(b=>b.Id == b.Id)
            
        {
            AddInclude(b => b.Exercise);
            AddInclude(b => b.CreatedBy);
        }
    }
}
