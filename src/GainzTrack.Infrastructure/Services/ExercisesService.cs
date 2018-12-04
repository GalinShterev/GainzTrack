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
        private readonly ApplicationDbContext _context;
        private readonly IRepository _repository;
        public ExercisesService(ApplicationDbContext context,IRepository repository)
        {
            _context = context;
            _repository = repository;
        }
        public IEnumerable<string> GetExercisesNames()
        {
            return _context.Exercises.Select(x => x.ExerciseName).ToList();
        }
        public Exercise GetSingleExerciseByName(string exerciseName)
        {
            var expression = new ExerciseByName(exerciseName);
            return _repository.GetBy<Exercise>(expression);
        }

    }
}
