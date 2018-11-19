using GainzTrack.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.Services
{
    public class ExercisesService : IExercisesService
    {
        private readonly ApplicationDbContext _context;
        public ExercisesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<string> GetExercisesNames()
        {
            return _context.Exercises.Select(x => x.Name).ToList();
        }
    }
}
