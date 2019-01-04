using GainzTrack.Core.DTOs.AchievementsDTOs;
using GainzTrack.Core.Entities;
using GainzTrack.Core.Enums;
using GainzTrack.Core.Expressions;
using GainzTrack.Core.Interfaces;
using GainzTrack.Infrastructure.Identity;
using GainzTrack.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GainzTrack.Infrastructure.Services
{
    public class AchievementService : IAchievementService
    {
        private readonly IRepository _repository;
        private readonly IExercisesService _exercisesService;
        private readonly IUserService _userService;
        private readonly IVideoService _videoService;
        public AchievementService(IRepository repository,IExercisesService exercisesService, IUserService userService,IVideoService videoService)
        {
            _repository = repository;
            _exercisesService = exercisesService;
            _userService = userService;
            _videoService = videoService;
        }

        public void ApproveAchievement(AchievementUser achievementUser)
        {
            achievementUser.IsApproved = true;
            _repository.Update<AchievementUser>(achievementUser);
        }

        public Achievement CreateAchievement(CreateAchievementDto dto)
        {
            var exercise = _exercisesService.GetSingleExerciseByName(dto.ExerciseName);
            if(exercise == null)
            {
                throw new InvalidOperationException("Invalid exercise");
            }
            var createdBy = _userService.GetMainUserByUsername(dto.CreatorUsername);
            var overloadType = (OverloadType)Enum.Parse(typeof(OverloadType), dto.OverloadType);
            var difficulty = (ExerciseDifficulty)Enum.Parse(typeof(ExerciseDifficulty), dto.Difficulty);
            var achievementEntity = new Achievement
            {
                AchievementPointsGain = dto.AchievementPoints,
                CreatedBy = createdBy,
                Exercise = exercise,
                OverloadAmount = dto.OverloadAmount,
                OverloadType = overloadType,
                Difficulty = difficulty
            };

           return _repository.Add<Achievement>(achievementEntity);

        }

        public AchievementUser CreateAchievementUser(CreateAchievementUserDto dto)
        {
            var user = _userService.GetMainUserByUsername(dto.Username);

            var achievement = _repository.GetById<Achievement>(dto.AchievementId);

            if (achievement == null)
                throw new InvalidOperationException("Invalid achievement");

            var entity = new AchievementUser
            {
                Achievement = achievement,
                User = user,
                IsApproved = false,
                VideoId = dto.VideoId
            };

            return _repository.Add<AchievementUser>(entity);
        }

        public void DenyAchievement(AchievementUser achievementUser)
        {
            _repository.Delete<AchievementUser>(achievementUser);
        }

        public IEnumerable<Achievement> FilterAchievements(ExerciseDifficulty difficulty)
        {
            //Int value of all flags summed
            if((int)difficulty == 14)
            {
                var allExpression = new AchievementsFilterWithExercise();
                return _repository.List<Achievement>(allExpression);
            }
              
            var filterExpression = new AchievementsFilterWithExercise(difficulty);
            return _repository.List<Achievement>(filterExpression);
            
        }

        public AchievementUser GetAchievementUserById(string achievementUserId)
        {
            var expression = new AchievementUserWithUserAndAchievementExpression(achievementUserId);
            var model = _repository.GetBy<AchievementUser>(expression);

            return model;
        }

        public AchievementUser[] ListAchievementUsers()
        {
            var expression = new AchievementUserWithUserAndAchievementExpression();
            var achievements = _repository.List<AchievementUser>(expression);

            return achievements.ToArray();
        }
    }
}
