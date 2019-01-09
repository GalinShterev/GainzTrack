using GainzTrack.Core.Entities;
using GainzTrack.Core.Expressions;
using GainzTrack.Core.Interfaces;
using GainzTrack.Web.Interfaces;
using GainzTrack.Web.ViewModels.UsersViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.Services
{
    public class UsersViewService : IUsersViewService
    {
        private readonly IRepository _repository;
        private readonly IUserService _userService;
        private readonly IWorkoutViewService _workoutViewService;

        public UsersViewService(IRepository repository,
            IUserService userService,
            IWorkoutViewService workoutViewService)
        {
            _repository = repository;
            _userService = userService;
            _workoutViewService = workoutViewService;
        }

        public GetAllUsersViewModel FetchAllUsers()
        {
            var expression = new MainUsersWithTitlesExpression();
            var users = _repository.List<MainUser>(expression).Select(x => new SingleUserViewModel
            {
                Username = x.Username,
                AchievementPoints = x.AchievementPoints.ToString(),
                Title = _userService.GetTitleForAchievementPoints(x.AchievementPoints).Name,
                Achievements = x.AchievementUsers.Count.ToString(),
                WorkoutsCreated = x.WorkoutRoutines.Count().ToString(),
                Avatar = _userService.GetAvatar(x.Username),
                Color = _userService.GetTitleForAchievementPoints(x.AchievementPoints).Color
            }).ToList();

            return new GetAllUsersViewModel
            {
                Users = users
            };
        }

        public ProfileViewModel GetUserProfile(string username)
        {
            var user = _userService.GetMainUserByUsernameWithIncludes(username);
            var titleForUser = _userService.GetTitleForAchievementPoints(user.AchievementPoints);
            var avatarPath = _userService.GetAvatar(username);
            var workouts = _workoutViewService.GetWorkoutsPreviewByName(username);
            return new ProfileViewModel
            {
                Username = user.Username,
                Achievements = user.AchievementUsers.Select(x => x.Achievement).ToArray(),
                Workouts = workouts,
                Title = titleForUser.Name,
                Avatar = avatarPath,
                Color = titleForUser.Color
            };
            
        }
    }
}
