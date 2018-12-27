using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.Controllers
{
    public class AdministrationController : Controller
    {
        [Authorize(Roles="Admin")]
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
