using GainzTrack.Core.Data;
using GainzTrack.Core.Interfaces;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GainzTrack.Web.Services
{
    public class ExercisesService : IExercisesService
    {
        private readonly ApplicationDbContext _context;

        public ExercisesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<string> ReturnExercisesNames()
        {
            return _context.Exercises.Select(x => x.Name).ToList();
        }
    }
}
