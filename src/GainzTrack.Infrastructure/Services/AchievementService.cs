using GainzTrack.Core.DTOs.AchievementsDTOs;
using GainzTrack.Core.Entities;
using GainzTrack.Core.Enums;
using GainzTrack.Core.Expressions;
using GainzTrack.Core.Interfaces;
using GainzTrack.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Infrastructure.Services
{
    public class AchievementService : IAchievementService
    {
        private readonly IRepository _repository;
        private readonly IExercisesService _exercisesService;
        private readonly IUserService _userService;
        public AchievementService(IRepository repository,IExercisesService exercisesService, IUserService userService)
        {
            _repository = repository;
            _exercisesService = exercisesService;
            _userService = userService;
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
    }
}
