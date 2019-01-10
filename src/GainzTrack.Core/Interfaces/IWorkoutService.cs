using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Interfaces
{
    public interface IWorkoutService
    {
        bool DeleteWorkout(string id);
        void AddWorkoutUse(string workoutId, string username);
    }
}
