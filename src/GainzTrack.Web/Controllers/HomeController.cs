using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GainzTrack.Web.Models;
using GainzTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using GainzTrack.Web.ViewModels.HomeViewModels;
using GainzTrack.Core.Interfaces;

namespace GainzTrack.Web.Controllers
{ 
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;

        public HomeController(ApplicationDbContext context,IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public IActionResult Index()
        {
            if(this.User.Identity.IsAuthenticated == true)
            {
                var user = _context.MainUsers.Include(x => x.Title).FirstOrDefault(x => x.IdentityUserId == _userService.GetIdentityIdWithUsername(this.User.Identity.Name));

                var workouts = _context.WorkoutRoutines.Include(x=>x.WorkoutDays).Where(x => x.CreatorId == user.Id).ToArray();

                var model = new HomeViewModel
                {
                    User = user,
                    Workouts = workouts
                };

                return View("Profile", model);
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
