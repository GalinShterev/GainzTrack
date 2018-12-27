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

        public UsersViewService(IRepository repository)
        {
            _repository = repository;
        }

        public GetAllUsersViewModel FetchAllUsers()
        {
            var expression = new MainUsersWithTitlesExpression();
            var users = _repository.List<MainUser>(expression).Select(x => new SingleUserViewModel
            {
                Username = x.Username,
                AchievementPoints = x.AchievementPoints.ToString(),
                Title = x.Title.Name,
                Achievements = x.AchievementUsers.Count.ToString(),
                WorkoutsCreated = x.WorkoutRoutines.Count().ToString(),

            }).ToList();

            return new GetAllUsersViewModel
            {
                Users = users
            };
        }
    }
}
