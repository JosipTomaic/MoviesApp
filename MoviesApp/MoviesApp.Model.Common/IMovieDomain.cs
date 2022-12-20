using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Model.Common
{
    public interface IMovieDomain
    {
        Guid Id { get; set; }

        int TmbdId { get; set; }

        string OriginalTitle { get; set; }

        double Popularity { get; set; }

        List<int> GenreIds { get; set; }

        DateTime? ReleaseDate { get; set; }

        DateTime? DateCreated { get; set; }

        IEnumerable<IMovieGenreDomain> MovieGenres { get; set; }
        IEnumerable<ICrewMemberMovieCreditDomain> CrewMemberMovieCredits { get; set; }
    }
}
