﻿using GainzTrack.Core.DTOs.ExercisesDTOs;
using GainzTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Core.Interfaces
{
    public interface IExercisesService
    {
        IEnumerable<string> GetExercisesNames();
        Exercise GetSingleExerciseByName(string exerciseName);
        bool HasExercise(string exerciseName);
        Exercise AddExercise(AddExerciseDto dto);
    }
}
