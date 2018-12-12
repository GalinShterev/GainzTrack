using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.ViewModels.WorkoutViewModels
{
    public class EditWorkoutViewModel
    {
        public string WorkoutId { get; set; }

        public string Name { get; set; }

        public bool IsPublic { get; set; }

        public DayOfWeek[] Days { get; set; }

        public string[] ExerciseName { get; set; }
    }
}
