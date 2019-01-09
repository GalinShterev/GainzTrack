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
                Workout = workout
            };
        }

        public WorkoutPreviewViewModel GetWorkoutPreviewById(string id)
        {
            var workoutExpression = new WorkoutRoutineByIdWithIncludes(id);
            var workout = _repository.GetBy<WorkoutRoutine>(workoutExpression);

            return new WorkoutPreviewViewModel
            {
                Workout = workout
            };
        }

        public WorkoutsPreviewViewModel GetWorkoutsPreviewByName(string username)
        {
            var user = _userService.GetMainUserByUsername(username);
            var expression = new WorkoutRoutineWithWourkoutDaysExpression(user.Id);
            var workouts = _repository.List<WorkoutRoutine>(expression);

            return new WorkoutsPreviewViewModel
            {
                Workouts = workouts.ToArray()
            };
        }
    }
}
