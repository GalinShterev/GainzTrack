using GainzTrack.Core.DTOs.ExercisesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.Interfaces
{
    public interface IExercisesViewService
    {
        AddExerciseDto GetAddExerciseDto(string exerciseName,string videoUrl);
    }
}
