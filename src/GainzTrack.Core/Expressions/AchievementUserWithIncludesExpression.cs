using GainzTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Expressions
{
    public class AchievementUserWithIncludesExpression : BaseExpression<AchievementUser>
    {
        public AchievementUserWithIncludesExpression(string username)
            :base(b=>b.User.Username != username && b.IsApproved == false)
        {
            AddInclude(b => b.User);
            AddInclude(b => b.Achievement);
        }
    }
}
