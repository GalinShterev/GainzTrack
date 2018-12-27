using GainzTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.ViewModels.HomeViewModels
{
    public class HomeViewModel
    {
        public string Username { get; set; }
        public MainUser User { get; set; }
        public IEnumerable<WorkoutRoutine> Workouts { get; set; }
    }
}
