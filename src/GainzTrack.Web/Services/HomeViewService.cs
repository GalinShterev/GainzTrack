using GainzTrack.Core.Entities;
using GainzTrack.Core.Expressions;
using GainzTrack.Core.Interfaces;
using GainzTrack.Web.Interfaces;
using GainzTrack.Web.ViewModels.HomeViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.Services
{
    public class HomeViewService : IHomeViewService
    {
        private readonly IRepository _repository;
        private readonly IUserService _userService;
        public HomeViewService(IRepository repository,IUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public HomeViewModel GetHomeViewModel(string username)
        {
            var identityUserId = _userService.GetIdentityIdWithUsername(username);
            var userExpression = new MainUserWithTitleExpression(identityUserId);

            var user = _repository.GetBy<MainUser>(userExpression);

            var workoutExpression = new WorkoutRoutineWithWourkoutDaysExpression(user.Id);
            var workout = _repository.List<WorkoutRoutine>(workoutExpression);

            return new HomeViewModel
            {
                User = user,
                Workouts = workout
            };
        }
    }
}
