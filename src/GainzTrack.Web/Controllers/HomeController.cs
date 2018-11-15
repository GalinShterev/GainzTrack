using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GainzTrack.Web.Models;
using GainzTrack.Core.Data;
using Microsoft.EntityFrameworkCore;
using GainzTrack.Web.ViewModels.HomeViewModels;

namespace GainzTrack.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if(this.User.Identity.IsAuthenticated == true)
            {
                var user = _context.User.Include(x => x.Title).FirstOrDefault(x => x.UserName == this.User.Identity.Name);
                var workouts = _context.WorkoutRoutines.Where(x => x.CreatorId == user.Id).ToArray();

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
