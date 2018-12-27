using GainzTrack.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersViewService _usersViewService;

        public UsersController(IUsersViewService usersViewService)
        {
            _usersViewService = usersViewService; 
        }


        public IActionResult All()
        {
            var model = _usersViewService.FetchAllUsers();
            return this.View("GetAllUsers",model);
        }


    }

}
