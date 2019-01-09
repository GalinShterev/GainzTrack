using GainzTrack.Core.Entities;
using GainzTrack.Web.ViewModels.WorkoutViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.ViewModels.UsersViewModels
{
    public class ProfileViewModel
    {
        public string Username { get; set; }

        public string Title { get; set; }

        public string Color { get; set; }

        public string Avatar { get; set; }

        public Achievement[] Achievements { get; set; }

        public IEnumerable<WorkoutPreviewViewModel> Workouts { get; set; }
    }
}
