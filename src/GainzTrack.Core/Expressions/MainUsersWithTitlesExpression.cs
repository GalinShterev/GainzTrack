﻿using GainzTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Expressions
{
    public class MainUsersWithTitlesExpression : BaseExpression<MainUser>
    {
        public MainUsersWithTitlesExpression()
            :base(b=>b == b)
        {
            AddInclude(b => b.WorkoutRoutines);
            AddInclude(b => b.AchievementUsers);
            AddInclude("AchievementUsers.Achievement");
        }
    }
}
