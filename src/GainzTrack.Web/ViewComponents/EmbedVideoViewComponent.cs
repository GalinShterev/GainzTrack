using GainzTrack.Core.Entities;
using GainzTrack.Core.Expressions;
using GainzTrack.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.ViewComponents
{
    public class EmbedVideoViewComponent : ViewComponent
    {
        private readonly IRepository _repository;
        public EmbedVideoViewComponent(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var expression = new AchievementsWithExercisesExpression(id);
            var videoUrl = _repository.GetBy<Achievement>(expression).Exercise.VideoUrl;

            return this.View("Default",videoUrl);
        }
    }
}
