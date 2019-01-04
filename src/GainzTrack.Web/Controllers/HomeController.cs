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
using GainzTrack.Web.Interfaces;
using GainzTrack.Web.Attributes;

namespace GainzTrack.Web.Controllers
{ 
    public class HomeController : Controller
    {
        private readonly IHomeViewService _homeViewService;

        public HomeController(ApplicationDbContext context,
            IHomeViewService homeViewService)
        {
            _homeViewService = homeViewService;
        }

        public IActionResult Index()
        {
            if(this.User.Identity.IsAuthenticated == true)
            {
               var model = _homeViewService.GetHomeViewModel(this.User.Identity.Name);
               return View("HomeTestView", model);
            }
            return View();
        }

        [AjaxOnlyAttribute]
        public IActionResult GetHomeFeed()
        {
            var model = _homeViewService.GetHomeViewModel(this.User.Identity.Name);
            return this.View(model);
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

        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
