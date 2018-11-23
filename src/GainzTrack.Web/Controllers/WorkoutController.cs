using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GainzTrack.Core.Entities;
using GainzTrack.Core.Interfaces;
using GainzTrack.Infrastructure.Data;
using GainzTrack.Web.ViewModels.WorkoutViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GainzTrack.Web.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        public WorkoutController(ApplicationDbContext context,IUserService userService)
        {
            _context = context;
            _userService = userService;
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
                return Redirect("/Home/Index");
            }
            var identityUserId = _userService.GetIdentityIdWithUsername(this.User.Identity.Name);

            var mainUserId = _context.MainUsers.FirstOrDefault(x => x.IdentityUserId == identityUserId).Id;

            var workout = new WorkoutRoutine
            {
                IsPublic = viewModel.IsPublic,
                Name = viewModel.Name,
                CreatorId = mainUserId,
            };

            var workoutDays = SetUpInitialWorkoutDays(workout.Id);

            workout.WorkoutDays = workoutDays;
            //TODO:Validation maybe
            _context.WorkoutRoutines.Add(workout);
            _context.SaveChanges();


            return Redirect("/Home/Index");
        }

        private ICollection<WorkoutDay> SetUpInitialWorkoutDays(string workoutRoutineId)
        {
            var workouts = new WorkoutDay[]
             {
                new WorkoutDay
                {
                    Day = DayOfWeek.Monday,
                    WorkoutRoutineId =workoutRoutineId
                },
                new WorkoutDay
                {
                    Day = DayOfWeek.Tuesday,
                    WorkoutRoutineId = workoutRoutineId
                },
                new WorkoutDay
                {
                    Day = DayOfWeek.Wednesday,
                    WorkoutRoutineId = workoutRoutineId
                },
                new WorkoutDay
                {
                    Day = DayOfWeek.Thursday,
                    WorkoutRoutineId = workoutRoutineId
                },
                new WorkoutDay
                {
                    Day = DayOfWeek.Friday,
                    WorkoutRoutineId = workoutRoutineId
                },
                new WorkoutDay
                {
                    Day = DayOfWeek.Saturday,
                    WorkoutRoutineId = workoutRoutineId
                },
                new WorkoutDay
                {
                    Day = DayOfWeek.Sunday,
                    WorkoutRoutineId = workoutRoutineId
                }
            };
            return workouts.ToList();
        }
    }
}