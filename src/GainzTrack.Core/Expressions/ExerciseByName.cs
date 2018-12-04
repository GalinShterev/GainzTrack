using GainzTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Expressions
{
    public class ExerciseByName :BaseExpression<Exercise>
    {
        public ExerciseByName(string exerciseName)
            :base(b=>b.ExerciseName == exerciseName)
        {

        }
    }
}
