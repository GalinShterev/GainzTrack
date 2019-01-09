using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.ViewModels.UsersViewModels
{
    public class SingleUserViewModel
    {
        public string Username { get; set; }

        public string Title { get; set; }

        public string Avatar { get; set; }

        public string Color { get; set; }

        public string AchievementPoints { get; set; }

        public string WorkoutsCreated { get; set; }

        public string Achievements { get; set; }
    }
}
