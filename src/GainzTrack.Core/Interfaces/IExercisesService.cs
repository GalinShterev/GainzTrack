using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Interfaces
{
    public interface IExercisesService
    {
        IEnumerable<string> ReturnExercisesNames();
    }
}
