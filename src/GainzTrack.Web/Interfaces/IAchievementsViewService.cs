using GainzTrack.Core.DTOs.AchievementsDTOs;
using GainzTrack.Core.Entities;
using GainzTrack.Web.ViewModels.AchievementsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.Interfaces
{
    public interface IAchievementsViewService
    {
        AchievementViewModel[] ListAchievements(IEnumerable<Achievement> achievements);
        AttemptAchievementViewModel GetAchievementAttempt(string id);
        CreateAchievementUserDto GetAchievementUserDto(string username, string videoId, string achievementId);
        EditAchievementDto GetEditAchievementDto(string achievementId);
        IEnumerable<AchievementViewModel> ListAchievementUsers(IEnumerable<Achievement> achievements, string username);
    }
}
