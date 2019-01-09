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
using GainzTrack.Web.Interfaces;
using GainzTrack.Web.ViewModels;

namespace GainzTrack.Web.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRepository _repository;
        private readonly IExercisesService _exercisesService;
        private readonly IHomeViewService _homeViewService;
        private readonly IWorkoutViewService _workoutViewService;
        private readonly IWorkoutService _workoutService;

        public WorkoutController(IUserService userService,
            IRepository repository, IExercisesService exercisesService,
            IHomeViewService homeViewService, 
            IWorkoutViewService workoutViewService,
            IWorkoutService workoutService)
        {
            _userService = userService;
            _repository = repository;
            _exercisesService = exercisesService;
            _homeViewService = homeViewService;
            _workoutViewService = workoutViewService;
            _workoutService = workoutService;
        }

        public IActionResult Index()
        {
            var model = _workoutViewService.GetAllWorkoutsPreview();
            return View(model);
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

            var identityUserId = _userService.GetIdentityIdByUsername(this.User.Identity.Name);

            var mainUser = _userService.GetMainUserByIdentityId(identityUserId);

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

            return Redirect("/Workout/Index");
        }

        public IActionResult Edit(string id, string name)
        {
            var expression = new WorkoutWithDaysByWorkoutNameExpression(id, name);
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

            var getExpression = new WorkoutWithDaysByWorkoutNameExpression(viewModel.WorkoutId, viewModel.Name);
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

            return Redirect($"/Users/ViewProfile?username={this.User.Identity.Name}");
        }


        public IActionResult Delete(string id)
        {
            var model = _workoutViewService.GetWorkoutPreviewById(id);
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Delete(DeleteWorkoutViewModel viewModel)
        {
            try
            {
                _workoutService.DeleteWorkout(viewModel.Id);
            }
            catch(InvalidOperationException ex)
            {
                return this.View("Error", new ErrorViewModel { Message = ex.Message });
            }

            return Redirect($"/Users/ViewProfile?username={this.User.Identity.Name}");
        }

        [AjaxOnlyAttribute]
        public IActionResult GetExercises(string id)
        {
            this.ViewData["DivId"] = id;
            return ViewComponent("AddExercises");
        }

        [AjaxOnlyAttribute]
        [HttpPost]
        public IActionResult GetSingleExercise(ExerciseWithNameAndDayViewModel viewModel)
        {
            return ViewComponent("GetSingleExercise", viewModel);
        }

        public IActionResult WorkoutFeed()
        {
            var model = _homeViewService.GetHomeViewModel(this.User.Identity.Name);
            return this.View(model);
        }

        public IActionResult WorkoutPreview(string workoutName)
        {
            var model = _workoutViewService.GetWorkoutPreviewByName(workoutName,this.User.Identity.Name);
            return this.View(model);
        }
        public IActionResult GetWorkoutsByAvailability(string availability)
        {
            var model = _workoutViewService.GetWorkoutsPreviewByName(this.User.Identity.Name);
            if (availability == "Public")
            {
                return this.View("GetPublicWorkouts",model);
            }
          
            return this.View("GetPrivateWorkouts",model);
        }

        [AjaxOnlyAttribute]
        public IActionResult AddExercise()
        {
            return this.View();
        }

        public IActionResult GetWorkoutModal(string workoutName,string username)
        {
            var model = _workoutViewService.GetWorkoutPreviewByName(workoutName, username);

            return this.View("WorkoutModal",model);
        }

        private ICollection<WorkoutDay> SetUpInitialWorkoutDays(string workoutRoutineId, DayOfWeek[] days, string[] exercises)
        {
            var workoutDays = new List<WorkoutDay>();
            if (days == null || exercises == null)
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