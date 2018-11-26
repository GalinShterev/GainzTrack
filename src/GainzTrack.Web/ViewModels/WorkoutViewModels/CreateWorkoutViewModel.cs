using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.ViewModels.WorkoutViewModels
{
    public class CreateWorkoutViewModel
    {
        [Required]
        public string Name { get; set; }

        public bool IsPublic { get; set; }

        public DayOfWeek[] Days { get; set; }


    }
}
