using GainzTrack.Core.Interfaces;
using GainzTrack.Web.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersViewService _usersViewService;
        private readonly IHostingEnvironment _environment;
        private readonly IUserService _userSerivce;

        public UsersController(IUsersViewService usersViewService
            ,IHostingEnvironment environment
            ,IUserService userService)
        {
            _usersViewService = usersViewService;
            _environment = environment;
            _userSerivce = userService;
        }


        public IActionResult All()
        {
            var model = _usersViewService.FetchAllUsers();
            return this.View("GetAllUsers",model);
        }


        public IActionResult ViewProfile(string username)
        {
            var model = _usersViewService.GetUserProfile(username);

            return this.View(model);
        }

        public IActionResult EditProfile()
        {
            var currentAvatar = _userSerivce.GetAvatar(this.User.Identity.Name);
            this.ViewData["avatarPath"] = currentAvatar;
            return this.View();
        }

        [HttpPost]
        public IActionResult EditProfile(IFormFile Image)
        {
            string uploadDir = Path.Combine(_environment.WebRootPath, "Avatars");
            string filePath = "Default";

            var userDir = Path.Combine(uploadDir, this.User.Identity.Name);
            
            if (Image != null)
            {
                Directory.CreateDirectory(userDir);
                
                if(Directory.GetFiles(userDir).Length != 0)
                    System.IO.File.Delete(Directory.GetFiles(userDir).First());

                var uploadTemp = Path.Combine(uploadDir, userDir, Image.FileName);
                filePath = Path.Combine(uploadDir, userDir);
                using (var stream = new FileStream(uploadTemp, FileMode.Create))
                {
                    Image.CopyTo(stream);
                }
                _userSerivce.UpdateAvatar(this.User.Identity.Name, filePath);
            }
            else
            {
                _userSerivce.UpdateAvatar(this.User.Identity.Name);
            }

            return RedirectToAction("ViewProfile", new { username = this.User.Identity.Name });
        }

    }

}
