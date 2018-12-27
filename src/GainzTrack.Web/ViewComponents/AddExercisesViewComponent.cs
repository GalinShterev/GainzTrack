using GainzTrack.Core.Entities;
using GainzTrack.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.ViewComponents
{
    public class AddExercisesViewComponent : ViewComponent
    {
        private readonly IRepository _repository;
        public AddExercisesViewComponent(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var exercises = _repository.List<Exercise>();
            return this.View(exercises);
        }
    }
}
