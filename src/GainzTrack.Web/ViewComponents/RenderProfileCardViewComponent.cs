using GainzTrack.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.ViewComponents
{
    public class RenderProfileCardViewComponent : ViewComponent
    {
        private readonly IHomeViewService _homeViewService;
        public RenderProfileCardViewComponent(IHomeViewService homeViewService)
        {
            _homeViewService = homeViewService;
        }
        public IViewComponentResult Invoke()
        {
            var model = _homeViewService.GetHomeViewModel(this.User.Identity.Name);
            return this.View(model);
        }
    }
}
