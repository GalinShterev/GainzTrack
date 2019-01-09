using GainzTrack.Web.ViewModels.UsersViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.Interfaces
{
    public interface IUsersViewService
    {
        GetAllUsersViewModel FetchAllUsers();
        ProfileViewModel GetUserProfile(string username);
    }
}
