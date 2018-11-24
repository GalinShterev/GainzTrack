using GainzTrack.Web.ViewModels.HomeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.Interfaces
{
    public interface IHomeViewService
    {
        HomeViewModel GetHomeViewModel(string username);
    }
}
