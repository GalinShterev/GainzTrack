using GainzTrack.Core.DTOs.AchievementsDTOs;
using GainzTrack.Core.Entities;
using GainzTrack.Core.Expressions;
using GainzTrack.Core.Interfaces;
using GainzTrack.Web.Interfaces;
using GainzTrack.Web.ViewModels.AchievementsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.Services
{
    public class AchievementsViewService : IAchievementsViewService
    {
        private readonly IRepository _repository;
        public AchievementsViewService(IRepository repository)
        {
            _repository = repository;
        }
        public AttemptAchievementViewModel GetAchievementAttempt(string id)
        {
            var expression = new AchievementsWithExercisesExpression(id);
            var achievement =_repository.GetBy<Achievement>(expression);

            return new AttemptAchievementViewModel
            {
                Difficulty = achievement.Difficulty.ToString(),
                ExerciseName = achievement.Exercise.ExerciseName,
                Id = achievement.Id,
                OverloadAmount = achievement.OverloadAmount,
                OverloadType = achievement.OverloadType.ToString(),
                Points = achievement.AchievementPointsGain
               
            };
        }

        public CreateAchievementUserDto GetAchievementUserDto(string username,string videoId,string achievementId)
        {
            return new CreateAchievementUserDto
            {
                AchievementId = achievementId,
                Username = username,
                VideoId = videoId

            };
            
        }

        public AchievementViewModel[] ListAchievements(IEnumerable<Achievement> achievements)
        {
            return achievements.Select(x => new AchievementViewModel
            {
                Difficulty = x.Difficulty.ToString(),
                ExerciseName = x.Exercise.ExerciseName,
                OverloadAmount = x.OverloadAmount,
                Points = x.AchievementPointsGain,
                OverloadType = x.OverloadType.ToString(),
                Id = x.Id
                
            }).ToArray();
        }
    }
}
