using GainzTrack.Core.DTOs.ExercisesDTOs;
using GainzTrack.Core.Enums;
using GainzTrack.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.Services
{
    public class ExercisesViewService : IExercisesViewService
    {
        public AddExerciseDto GetAddExerciseDto(string exerciseName, string videoUrl)
        {
            videoUrl = videoUrl.Replace("watch?v=","embed/");
            return new AddExerciseDto
            {
                ExerciseName = exerciseName,
                MusculeGroup = MusculeGroupEnum.Abs,
                VideoUrl = videoUrl
            };
        }
    }
}
