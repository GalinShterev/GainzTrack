using GainzTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Expressions
{
    public class MainUserWithAllIncludesExpression : BaseExpression<MainUser>
    {
        public MainUserWithAllIncludesExpression(string username)
            :base(b=>b.Username == username)
        {
            AddInclude(b => b.WorkoutRoutines);
            AddInclude(b => b.AchievementUsers);
            AddInclude("AchievementUsers.Achievement");

        }
    }
}
