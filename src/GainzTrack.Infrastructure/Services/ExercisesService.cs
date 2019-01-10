using GainzTrack.Core.DTOs.ExercisesDTOs;
using GainzTrack.Core.Entities;
using GainzTrack.Core.Expressions;
using GainzTrack.Core.Interfaces;
using GainzTrack.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Infrastructure.Services
{
    public class ExercisesService : IExercisesService
    {
        private readonly IRepository _repository;
        public ExercisesService(IRepository repository)
        {
            _repository = repository;
        }

        public Exercise AddExercise(AddExerciseDto dto)
        {
            var entity = new Exercise
            {
                ExerciseName = dto.ExerciseName,
                VideoUrl = dto.VideoUrl,
                MusculeGroup = dto.MusculeGroup
            };
            return _repository.Add<Exercise>(entity);

        }

        public IEnumerable<string> GetExercisesNames()
        {
            return _repository.List<Exercise>().Select(x => x.ExerciseName).ToList();
        }
        public Exercise GetSingleExerciseByName(string exerciseName)
        {
            var expression = new ExerciseByName(exerciseName);
            return _repository.GetBy<Exercise>(expression);
        }

        public bool HasExercise(string exerciseName)
        {
            var expression = new ExerciseByName(exerciseName);

            return _repository.GetBy<Exercise>(expression) == null ? false : true;

        }
    }
}
