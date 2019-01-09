using GainzTrack.Core.Entities;
using GainzTrack.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Infrastructure.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IRepository _repository;
        public WorkoutService(IRepository repository)
        {
            _repository = repository;
        }

        public bool DeleteWorkout(string id)
        {
           var entity = _repository.GetById<WorkoutRoutine>(id) ?? throw new InvalidOperationException("Invalid id");

            _repository.Delete<WorkoutRoutine>(entity);
            return true;
        }
    }
}
