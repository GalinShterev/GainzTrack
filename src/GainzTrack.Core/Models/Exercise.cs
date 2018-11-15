using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Models
{
    public class Exercise : BaseEntity
    {
        public Exercise()
        {
            this.ExerciseWorkoutDays = new HashSet<ExerciseWorkoutDay>();
        }

        public string Name { get; set; }

        public string VideoUrl { get; set; }

        public virtual ICollection<ExerciseWorkoutDay> ExerciseWorkoutDays { get; set; }
        public virtual ICollection<Achievement> InAchievements { get; set; }
    }
}
