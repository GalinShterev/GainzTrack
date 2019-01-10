using GainzTrack.Core.Entities;
using GainzTrack.Core.Expressions;
using GainzTrack.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GainzTrack.Infrastructure.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IRepository _repository;
        private readonly IUserService _userService;
        public WorkoutService(IRepository repository,
            IUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        public void AddWorkoutUse(string workoutId, string username)
        {
            var expression = new WorkoutRoutineByIdWithIncludes(workoutId);
            var workout = _repository.GetBy<WorkoutRoutine>(expression);
            var user = _userService.GetMainUserByUsername(username);

            if (workout.TimesCopied.Any(x => x.UserId == user.Id))
                return;

            var timesCopiedEntity = new CopiedWorkoutsFromUsers
            {
                User = user,
                WorkoutRoutine = workout
            };

            _repository.Add<CopiedWorkoutsFromUsers>(timesCopiedEntity);

            return;
        }

        public bool DeleteWorkout(string id)
        {
           var entity = _repository.GetById<WorkoutRoutine>(id) ?? throw new InvalidOperationException("Invalid id");

            _repository.Delete<WorkoutRoutine>(entity);
            return true;
        }
    }
}
