using GainzTrack.Core.DTOs.AchievementsDTOs;
using GainzTrack.Core.Entities;
using GainzTrack.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Interfaces
{
    public interface IAchievementService
    {
        Achievement CreateAchievement(CreateAchievementDto dto);
        IEnumerable<Achievement> FilterAchievements(ExerciseDifficulty difficulty);
        AchievementUser CreateAchievementUser(CreateAchievementUserDto dto);
        AchievementUser[] ListAchievementUsers();
        Achievement[] ListAchievements();
        AchievementUser GetAchievementUserById(string achievementUserId);
        void ApproveAchievement(AchievementUser achievementUser);
        void DenyAchievement(AchievementUser achievementUser);
        void EditAchievement(EditAchievementDto achievementDto);
    }
}
