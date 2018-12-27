using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.ViewModels.UsersViewModels
{
    public class GetAllUsersViewModel
    {
        public ICollection<SingleUserViewModel> Users { get; set; }
    }
}
