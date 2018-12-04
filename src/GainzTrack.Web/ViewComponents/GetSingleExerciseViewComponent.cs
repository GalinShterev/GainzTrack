using GainzTrack.Core.Entities;
using GainzTrack.Core.Expressions;
using GainzTrack.Core.Interfaces;
using GainzTrack.Web.ViewModels.ExerciseViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.ViewComponents
{
    public class GetSingleExerciseViewComponent : ViewComponent
    {
        private readonly IRepository _repository;
        public GetSingleExerciseViewComponent(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<IViewComponentResult> InvokeAsync(ExerciseWithNameAndDayViewModel viewModel)
        {
            var expression = new ExerciseByName(viewModel.Name);
            var exercise = _repository.GetBy<Exercise>(expression);

            this.ViewData["DayId"] = viewModel.Day;

            return this.View(exercise);
        }
    }
}
