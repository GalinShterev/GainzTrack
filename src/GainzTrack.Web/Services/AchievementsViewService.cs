using GainzTrack.Core.Entities;
using GainzTrack.Web.Interfaces;
using GainzTrack.Web.ViewModels.AchievementsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.Services
{
    public class AchievementsViewService : IAchievementsViewService
    {
        public AchievementViewModel[] ListAchievements(IEnumerable<Achievement> achievements)
        {
            return achievements.Select(x => new AchievementViewModel
            {
                Difficulty = x.Difficulty.ToString(),
                ExerciseName = x.Exercise.ExerciseName,
                OverloadAmount = x.OverloadAmount,
                Points = x.AchievementPointsGain,
                OverloadType = x.OverloadType.ToString()
                
            }).ToArray();
        }
    }
}
