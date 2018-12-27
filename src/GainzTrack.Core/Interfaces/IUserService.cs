using GainzTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Interfaces
{
    public interface IUserService
    {
        string GetIdentityIdByUsername(string username);
        MainUser GetMainUserByIdentityId(string identityId);
        MainUser GetMainUserByUsername(string username);
    }
}
