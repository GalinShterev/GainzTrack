using GainzTrack.Core.Interfaces;
using GainzTrack.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace GainzTrack.Web.Controllers
{
    public class ExercisesController : Controller
    {
        private readonly IExercisesService _exercisesService;
        private readonly IExercisesViewService _exercisesViewService;

        public ExercisesController(IExercisesService exercisesService, IExercisesViewService exercisesViewService)
        {
            _exercisesService = exercisesService;
            _exercisesViewService = exercisesViewService;
        }
        public IActionResult AddNewExercise(string exerciseName, string videoUrl)
        {
            //Check if exercise already exists
            if(exerciseName == null || videoUrl == null)
            {
                return Json(new { success = false, responseText = "Both fields are required and cannot be empty"});
            }

            bool hasExercise = _exercisesService.HasExercise(exerciseName);
            //Check if videoUrl is valid YouTube url
            if (!hasExercise)
            {
                var dto = _exercisesViewService.GetAddExerciseDto(exerciseName, videoUrl);
                _exercisesService.AddExercise(dto);

                return Json(new { success = true,responseText = "Exercise added successfully, you can find it in 'Existing Exercises'" });
            }

            //Add exercise to db

            return Json(new { success = false, responseText = "Exercise already exists" });
        }

        [HttpGet]
        public IActionResult AddExercisesToModal()
        {
            return ViewComponent("AddExercises");
        }
    }
}
