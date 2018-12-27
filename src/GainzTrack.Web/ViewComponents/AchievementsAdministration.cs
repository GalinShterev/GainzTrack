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
    public class AchievementsAdministration : ViewComponent
    {
        private readonly IRepository _repository;
        public AchievementsAdministration(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var expression = new AchievementsWithExercisesExpression();
            var achievements = _repository.List<Achievement>(expression);

            return this.View(achievements.ToArray());
        }
    }
}
