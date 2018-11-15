using GainzTrack.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.ViewModels.HomeViewModels
{
    public class HomeViewModel
    {
        public ApplicationUser User { get; set; }
        public WorkoutRoutine[] Workouts { get; set; }
    }
}
