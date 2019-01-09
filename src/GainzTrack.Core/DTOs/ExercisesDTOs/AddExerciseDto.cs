using GainzTrack.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.DTOs.ExercisesDTOs
{
    public class AddExerciseDto
    {
        public string ExerciseName { get; set; }

        public string VideoUrl { get; set; }

        public MusculeGroupEnum MusculeGroup { get; set; }
    }
}
