using GainzTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GainzTrack.Core.Expressions
{
    public class MainUserWithTitleExpression : BaseExpression<MainUser>
    {
        public MainUserWithTitleExpression(string identityUserId)
            :base(b => b.IdentityUserId == identityUserId)
        {
        }
    }
}
