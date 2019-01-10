using GainzTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.ViewModels.WorkoutViewModels
{
    public class TrainingViewModel
    {
        public string WorkoutId { get; set; }
        public string WorkoutName { get; set; }
        public string Day { get; set; }
        public IEnumerable<Exercise> Exercises { get; set; }
    }
}
