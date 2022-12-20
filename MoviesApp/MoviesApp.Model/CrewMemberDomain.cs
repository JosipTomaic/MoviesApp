using MoviesApp.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Model
{
    public class CrewMemberDomain: ICrewMemberDomain
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TmdbId { get; set; }
        public ICollection<ICrewMemberMovieCreditDomain> CrewMemberMovieCredits { get; set; }
    }
}
