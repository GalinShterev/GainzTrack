using GainzTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.ViewModels.HomeViewModels
{
    public class HomeViewModel
    {
        public MainUser User { get; set; }
        public WorkoutRoutine[] Workouts { get; set; }
    }
}
