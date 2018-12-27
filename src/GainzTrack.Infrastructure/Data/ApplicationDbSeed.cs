using GainzTrack.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GainzTrack.Infrastructure.Data
{
    public class ApplicationDbSeed
    {
        public static void Seed(ApplicationDbContext context, ILogger logger)
        {
            try
            {
                if (!context.Titles.Any())
                {
                    context.AddRange(GetConfiguredTitles());

                    context.SaveChanges();
                }
                if (!context.Exercises.Any())
                {
                    context.AddRange(GetConfiguredExercises());

                    context.SaveChanges();
                }
               

            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }

        private static IEnumerable<Exercise> GetConfiguredExercises()
        {
            return new List<Exercise>()
            {
                new Exercise(){ExerciseName = "Pull up",VideoUrl = "https://www.youtube.com/embed/eGo4IYlbE5g"},
                new Exercise(){ExerciseName = "Muscule up",VideoUrl = "https://www.youtube.com/embed/3SduiaXqAT4"},
                new Exercise(){ExerciseName = "Front lever",VideoUrl = "https://www.youtube.com/embed/H1jsJf8edpw"},
                new Exercise(){ExerciseName = "Planche",VideoUrl = "https://www.youtube.com/embed/YO5Ae08CgEE"},
                new Exercise(){ExerciseName = "Squat",VideoUrl = "https://www.youtube.com/embed/nEQQle9-0NA"},
                new Exercise(){ExerciseName = "Handstand",VideoUrl = "https://www.youtube.com/embed/-SL0l4JZ-44"},
                new Exercise(){ExerciseName = "Push up",VideoUrl = "https://www.youtube.com/embed/IODxDxX7oi4"},

            };
        }

        private static IEnumerable<Title> GetConfiguredTitles()
        {
            return new List<Title>()
            {
                new Title(){ Name = "Newbie",RequiredAP = 0},
                new Title(){ Name = "Enthusiast",RequiredAP = 500}
            };
        }
    }
}
