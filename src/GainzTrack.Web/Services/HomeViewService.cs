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
        private readonly IWorkoutViewService _workoutViewService;
        private readonly IUsersViewService _userViewService;
        public HomeViewService(IRepository repository,
            IUserService userService,
            IWorkoutViewService workoutViewService,
            IUsersViewService userViewService)
        {
            _repository = repository;
            _userService = userService;
            _workoutViewService = workoutViewService;
            _userViewService = userViewService;
        }

        public HomeViewModel GetHomeViewModel(string username)
        {
            var workouts = _workoutViewService.GetAllWorkoutsPreview().Take(6);
            var user = _userViewService.GetUserProfile(username, username);
            var nextTitle = _userService.GetNextTitle(user.Title.Name);
            double progressPercent = ((double)user.Title.RequiredAP / nextTitle.RequiredAP)* 100;
            return new HomeViewModel
            {
                Profile = user,
                NextTitle = nextTitle.Name,
                ProgressPercent = progressPercent,
                Workouts = workouts
            };
        }
    }
}
