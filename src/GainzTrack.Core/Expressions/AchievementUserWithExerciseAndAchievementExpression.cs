using GainzTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Expressions
{
    public class AchievementUserWithUserAndAchievementExpression : BaseExpression<AchievementUser>
    {
        public AchievementUserWithUserAndAchievementExpression(string id)
            :base(b=>b.Id == id)
        {
            AddInclude(b => b.Achievement);
            AddInclude(b => b.User);
        }
        public AchievementUserWithUserAndAchievementExpression()
            :base(b=>b == b)
        {
            AddInclude(b => b.Achievement);
            AddInclude(b => b.User);
            AddInclude("Achievement.Exercise");
        }
    }
}
