using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GainzTrack.Web.Services
{
    public interface IExercisesService
    {
        IEnumerable<string> GetExercisesNames();
    }
}
