﻿using GainzTrack.Core.DTOs.AchievementsDTOs;
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

        public EditAchievementDto GetEditAchievementDto(string achievementId)
        {
            var expression = new AchievementsWithExercisesExpression(achievementId);
            var entity = _repository.GetBy<Achievement>(expression);

            return new EditAchievementDto
            {
                AchievementPoints = entity.AchievementPointsGain,
                CreatorUsername = entity.CreatedBy.Username,
                Difficulty = entity.Difficulty.ToString(),
                ExerciseName = entity.Exercise.ExerciseName,
                OverloadAmount = entity.OverloadAmount,
                OverloadType = entity.OverloadType.ToString(),
                Id = achievementId
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


        public IEnumerable<AchievementViewModel> ListAchievementUsers(IEnumerable<Achievement> achievements, string username)
        {
            

            return achievements.Select(x => new AchievementViewModel
            {
                Difficulty = x.Difficulty.ToString(),
                ExerciseName = x.Exercise.ExerciseName,
                OverloadAmount = x.OverloadAmount,
                Points = x.AchievementPointsGain,
                OverloadType = x.OverloadType.ToString(),
                Id = x.Id

            }).ToList();
        }
    }
}
