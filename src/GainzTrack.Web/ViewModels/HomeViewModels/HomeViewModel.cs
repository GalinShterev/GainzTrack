using GainzTrack.Core.Entities;
using GainzTrack.Web.ViewModels.UsersViewModels;
using GainzTrack.Web.ViewModels.WorkoutViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.ViewModels.HomeViewModels
{
    public class HomeViewModel
    {
        public ProfileViewModel Profile { get; set; }
        public string NextTitle { get; set; }
        public double ProgressPercent { get; set; }
        public IEnumerable<WorkoutPreviewViewModel> Workouts { get; set; }
    }
}
