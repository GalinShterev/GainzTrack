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

namespace GainzTrack.Web.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        private readonly IRepository _repository;
        public WorkoutController(ApplicationDbContext context,IUserService userService,IRepository repository)
        {
            _context = context;
            _userService = userService;
            _repository = repository;
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
                return this.BadRequest();
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

            var workoutDays = SetUpInitialWorkoutDays(workout.Id,viewModel.Days);
            workout.WorkoutDays = workoutDays;

            //TODO:Validation maybe
            _repository.Add<WorkoutRoutine>(workout);

            return Redirect("/Home/Index");
        }

        public IActionResult GetExercises()
        {
            return ViewComponent("AddExercises");
        }

        private ICollection<WorkoutDay> SetUpInitialWorkoutDays(string workoutRoutineId,DayOfWeek[] days)
        {
            var workoutDays = new List<WorkoutDay>();
            foreach (var day in days)
            {
                var workoutDay = new WorkoutDay
                {
                    Day = day,
                    WorkoutRoutineId = workoutRoutineId
                };

                workoutDays.Add(workoutDay);
            }

            return workoutDays;
        }
    }
}