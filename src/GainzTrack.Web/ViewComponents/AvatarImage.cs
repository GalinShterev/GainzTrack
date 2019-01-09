using GainzTrack.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.ViewComponents
{
    public class AvatarImage : ViewComponent
    {
        private readonly IUserService _userService;
        public AvatarImage(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string username)
        {

            var actualDir = _userService.GetAvatar(username);
            
            return this.View("",actualDir);
        }
    }
}
