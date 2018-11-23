using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Core.Interfaces
{
    public interface IExercisesService
    {
        IEnumerable<string> GetExercisesNames();
            
    }
}
