using GainzTrack.Web.ViewModels.WorkoutViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.Interfaces
{
    public interface IWorkoutViewService
    {
        WorkoutPreviewViewModel GetWorkoutPreview(string workoutName,string username);
        WorkoutsPreviewViewModel GetWorkoutsPreview(string username);
    }
}
