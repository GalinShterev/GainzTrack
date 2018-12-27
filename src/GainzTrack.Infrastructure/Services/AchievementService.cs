using GainzTrack.Core.DTOs.AchievementsDTOs;
using GainzTrack.Core.Entities;
using GainzTrack.Core.Enums;
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
                throw new Exception("Invalid exercise");
            }
            var createdBy = _userService.GetMainUserByUsername(dto.CreatorUsername);
            var overloadType = (OverloadType)Enum.Parse(typeof(OverloadType), dto.OverloadType);
            var achievementEntity = new Achievement
            {
                AchievementPointsGain = dto.AchievementPoints,
                CreatedBy = createdBy,
                Exercise = exercise,
                OverloadAmount = dto.OverloadAmount,
                OverloadType = overloadType
            };

           return _repository.Add<Achievement>(achievementEntity);

        }
    }
}
