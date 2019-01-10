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
        IEnumerable<WorkoutPreviewViewModel> GetWorkoutsPreviewByName(string searchedUsername,string loggedInUsername);
        IEnumerable<WorkoutPreviewViewModel> GetAllWorkoutsPreview();
        TrainingViewModel GetTrainingModel(string workoutId, string day);
        IEnumerable<WorkoutPreviewViewModel> GetFeaturedWorkoutsPreview();
    }
}
