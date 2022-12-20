using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Model.Common
{
    public interface ICrewMemberDomain
    {
        Guid Id { get; set; }
        string Name { get; set; }
        int TmdbId { get; set; }
        ICollection<ICrewMemberMovieCreditDomain> CrewMemberMovieCredits { get; set; }
    }
}
