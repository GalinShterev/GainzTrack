using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Entities
{
    public class AchievementUser : BaseEntity
    {
        public string AchievementId { get; set; }
        public Achievement Achievement { get; set; }

        public string UserId { get; set; }
        public MainUser User { get; set; }
    }
}
