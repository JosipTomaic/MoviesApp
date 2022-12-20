using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Model.Common
{
    public interface IAPIMovieCredit
    {
        IEnumerable<IAPICrewMember> Cast { get; set; }
        IEnumerable<IAPICrewMember> Crew { get; set; }
    }
}
