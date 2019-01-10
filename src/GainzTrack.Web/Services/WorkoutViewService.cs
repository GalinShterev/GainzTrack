using GainzTrack.Core.Entities;
using GainzTrack.Core.Expressions;
using GainzTrack.Core.Interfaces;
using GainzTrack.Infrastructure.Identity;
using GainzTrack.Web.Interfaces;
using GainzTrack.Web.ViewModels.WorkoutViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.Services
{
    public class WorkoutViewService : IWorkoutViewService
    {
        private readonly IRepository _repository;
        private readonly IUserService _userService;
        private readonly UserManager<IdentityApplicationUser> _userManager;

        public WorkoutViewService(IRepository repository, IUserService userService, UserManager<IdentityApplicationUser> userManager)
        {
            _repository = repository;
            _userService = userService;
            _userManager = userManager;
        }

        public WorkoutPreviewViewModel GetWorkoutPreviewByName(string workoutName,string username)
        {
            var identityUser = _userManager.FindByNameAsync(username);
            var userExpression = new MainUserWithTitleExpression(identityUser.Result.Id);

            var user = _repository.GetBy<MainUser>(userExpression);

            var workoutExpression = new WorkoutRoutineWithWourkoutDaysExpression(user.Id,workoutName);
            var workout = _repository.GetBy<WorkoutRoutine>(workoutExpression);

            return new WorkoutPreviewViewModel
            {
                Id = workout.Id,
                AvatarUrl = _userService.GetAvatar(workout.Creator.Username),
                Creator = workout.Creator.Username,
                Days = workout.WorkoutDays.Count,
                Title = _userService.GetTitleForAchievementPoints(workout.Creator.AchievementPoints).Name,
                WorkoutName = workout.Name,
                WorkoutRoutine = workout
            };
        }

        public WorkoutPreviewViewModel GetWorkoutPreviewById(string id)
        {
            var workoutExpression = new WorkoutRoutineByIdWithIncludes(id);
            var workout = _repository.GetBy<WorkoutRoutine>(workoutExpression);

            return new WorkoutPreviewViewModel
            {
                Id = workout.Id,
                AvatarUrl = _userService.GetAvatar(workout.Creator.Username),
                Creator = workout.Creator.Username,
                Days = workout.WorkoutDays.Count,
                Title = _userService.GetTitleForAchievementPoints(workout.Creator.AchievementPoints).Name,
                WorkoutName = workout.Name,
                WorkoutRoutine = workout
            };
        }

        public IEnumerable<WorkoutPreviewViewModel> GetWorkoutsPreviewByName(string searchedUsername,string loggedInUsername)
        {
            var user = _userService.GetMainUserByUsername(searchedUsername);
            var expression = new WorkoutRoutineWithWourkoutDaysExpression(user.Id);
            var workouts = _repository.List<WorkoutRoutine>(expression);

            if (!workouts.All(x => x.Creator.Username == loggedInUsername))
                workouts = workouts.Where(x => x.IsPublic == true);

            return workouts.Select(x => new WorkoutPreviewViewModel
            {
                AvatarUrl = _userService.GetAvatar(searchedUsername),
                Creator = searchedUsername,
                Days = x.WorkoutDays.Count,
                Id = x.Id,
                Title = _userService.GetTitleForAchievementPoints(x.Creator.AchievementPoints).Name,
                WorkoutRoutine = x,
                WorkoutName = x.Name,
                TimesUsed = x.TimesCopied.Count
            }).ToList();
        }

        public IEnumerable<WorkoutPreviewViewModel> GetAllWorkoutsPreview()
        {
            var expression = new WorkoutRoutineByIdWithIncludes();
            var workouts = _repository.List<WorkoutRoutine>(expression);

            return workouts.Where(x=>x.IsPublic == true).Select(x => new WorkoutPreviewViewModel
            {
                Id = x.Id,
                Creator = x.Creator.Username,
                Days = x.WorkoutDays.Count,
                WorkoutName = x.Name,
                AvatarUrl = _userService.GetAvatar(x.Creator.Username),
                Title = _userService.GetTitleForAchievementPoints(x.Creator.AchievementPoints).Name,
                WorkoutRoutine = x,
                TimesUsed = x.TimesCopied.Count
            }).ToList();
        }

        public TrainingViewModel GetTrainingModel(string workoutId, string day)
        {
            var expression = new WorkoutWithDaysByWorkoutNameExpression(workoutId);
            var workout = _repository.GetBy<WorkoutRoutine>(expression);

            var actualDay = workout.WorkoutDays.Where(x => x.Day.ToString() == day).First();

            return new TrainingViewModel
            {
                WorkoutId = workout.Id,
                WorkoutName = workout.Name,
                Day = actualDay.Day.ToString(),
                Exercises = actualDay.ExerciseWorkoutDay.Select(x => x.Exercise).ToList()
            };
        }

        public IEnumerable<WorkoutPreviewViewModel> GetFeaturedWorkoutsPreview()
        {
            var expression = new WorkoutRoutineByIdWithIncludes();
            var workouts = _repository.List<WorkoutRoutine>(expression);



            return workouts.Where(x => x.IsPublic == true)
                .OrderByDescending(x => x.TimesCopied.Count).Take(6)
                .Select(x => new WorkoutPreviewViewModel
            {
                Id = x.Id,
                Creator = x.Creator.Username,
                Days = x.WorkoutDays.Count,
                WorkoutName = x.Name,
                AvatarUrl = _userService.GetAvatar(x.Creator.Username),
                Title = _userService.GetTitleForAchievementPoints(x.Creator.AchievementPoints).Name,
                WorkoutRoutine = x,
                TimesUsed = x.TimesCopied.Count
            }).ToList();
        }
    }
}
