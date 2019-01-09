using GainzTrack.Web.ViewModels.WorkoutViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.Interfaces
{
    public interface IWorkoutViewService
    {
        WorkoutPreviewViewModel GetWorkoutPreviewByName(string workoutName,string username);
        WorkoutPreviewViewModel GetWorkoutPreviewById(string id);
        WorkoutsPreviewViewModel GetWorkoutsPreviewByName(string username);
    }
}
