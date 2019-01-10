using GainzTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.ViewModels.WorkoutViewModels
{
    public class WorkoutPreviewViewModel
    {
        public string Id { get; set; }
        public string Creator { get; set; }
        public string AvatarUrl { get; set; }
        public string Title { get; set; }
        public int Days { get; set; }
        public string WorkoutName { get; set; }
        public int TimesUsed { get; set; }
        public WorkoutRoutine WorkoutRoutine { get; set; }
    }
}
