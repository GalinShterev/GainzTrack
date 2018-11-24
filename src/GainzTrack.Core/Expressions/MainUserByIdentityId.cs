using GainzTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Expressions
{
    public class MainUserByIdentityId : BaseExpression<MainUser>
    {
        public MainUserByIdentityId(string identityUserId)
            :base(b=>b.IdentityUserId == identityUserId)
        {

        }
    }
}
