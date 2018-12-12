using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GainzTrack.Core.Entities;
using GainzTrack.Core.Interfaces;
using GainzTrack.Infrastructure.Data;
using GainzTrack.Web.ViewModels.WorkoutViewModels;
using Microsoft.AspNetCore.Mvc;
using GainzTrack.Core.Expressions;
using GainzTrack.Web.Attributes;
using GainzTrack.Web.ViewModels.ExerciseViewModels;

namespace GainzTrack.Web.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        private readonly IRepository _repository;
        private readonly IExercisesService _exercisesService;
        public WorkoutController(ApplicationDbContext context, IUserService userService, IRepository repository, IExercisesService exercisesService)
        {
            _context = context;
            _userService = userService;
            _repository = repository;
            _exercisesService = exercisesService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateWorkoutViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            var identityUserId = _userService.GetIdentityIdWithUsername(this.User.Identity.Name);
            var mainUser = _repository
                .GetBy<MainUser>(new MainUserByIdentityId(identityUserId));

            var workout = new WorkoutRoutine
            {
                IsPublic = viewModel.IsPublic,
                Name = viewModel.Name,
                CreatorId = mainUser.Id,
            };

            var workoutDays = SetUpInitialWorkoutDays(workout.Id, viewModel.Days, viewModel.ExerciseName);
            workout.WorkoutDays = workoutDays;

            //TODO:Validation maybe
            _repository.Add<WorkoutRoutine>(workout);

            return Redirect("/Home/Index");
        }

        public IActionResult Edit(string id, string name)
        {
            var expression = new WorkoutRoutineWithWourkoutDaysExpression(id, name);
            var workoutRoutine = _repository.GetBy<WorkoutRoutine>(expression);

            return this.View(workoutRoutine);
        }
        [HttpPost]
        public IActionResult Edit(EditWorkoutViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            //Check if workout with such name and id exists in case its modified

            var getExpression = new WorkoutRoutineWithWourkoutDaysExpression(viewModel.WorkoutId, viewModel.Name);
            var workout = _repository.GetBy<WorkoutRoutine>(getExpression);

            var removeExpression = new WorkoutDaysByWorkoutRoutine(viewModel.WorkoutId);
            _repository.DeleteAllBy<WorkoutDay>(removeExpression);

            //Check for null workout

            //var days = workout.WorkoutDays.Select(x => x.Day).ToArray();
            var workoutDays = SetUpInitialWorkoutDays(workout.Id, viewModel.Days, viewModel.ExerciseName);


            workout.Name = viewModel.Name;
            workout.IsPublic = viewModel.IsPublic;
            workout.WorkoutDays = workoutDays;

            _repository.Update<WorkoutRoutine>(workout);

            return Redirect("/Home/Index");
        }



        [IsAjax]
        public IActionResult GetExercises(string id)
        {
            this.ViewData["DivId"] = id;
            return ViewComponent("AddExercises");
        }

        [IsAjax]
        [HttpPost]
        public IActionResult GetSingleExercise(ExerciseWithNameAndDayViewModel viewModel)
        {
            return ViewComponent("GetSingleExercise", viewModel);
        }



        private ICollection<WorkoutDay> SetUpInitialWorkoutDays(string workoutRoutineId, DayOfWeek[] days, string[] exercises)
        {
            var workoutDays = new List<WorkoutDay>();
            if (days == null)
                return workoutDays;

            foreach (var day in days)
            {
                var workoutDay = new WorkoutDay
                {
                    Day = day,
                    WorkoutRoutineId = workoutRoutineId,
                };


                var dayIntValue = (int)day;

                var exercisesForWorkoutDayCollection = GetExercisesForCurrentDay(dayIntValue, exercises, workoutDay);



                workoutDay.ExerciseWorkoutDay = exercisesForWorkoutDayCollection;
                workoutDays.Add(workoutDay);
            }

            return workoutDays;
        }

        private List<ExerciseWorkoutDay> GetExercisesForCurrentDay(int dayIntValue, string[] exercises, WorkoutDay workoutDay)
        {
            var exercisesForWorkoutDayCollection = new List<ExerciseWorkoutDay>();

            //Each exercise caries its day in the name (ex. Pull up-1)
            if (exercises.Any(x => x.Contains(dayIntValue.ToString())))
            {
                foreach (var exercise in exercises.Where(x => x.Contains(dayIntValue.ToString())))
                {
                    var parsedExerciseName = exercise.Split('-').First();
                    var exerciseEntity = _exercisesService.GetSingleExerciseByName(parsedExerciseName);

                    exercisesForWorkoutDayCollection.Add(new ExerciseWorkoutDay
                    {
                        Exercise = exerciseEntity,
                        WorkoutDay = workoutDay
                    });
                }
            }
            return exercisesForWorkoutDayCollection;
        }
    }
}