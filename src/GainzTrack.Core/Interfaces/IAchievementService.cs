using GainzTrack.Core.DTOs.AchievementsDTOs;
using GainzTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Interfaces
{
    public interface IAchievementService
    {
        Achievement CreateAchievement(CreateAchievementDto dto);
    }
}
