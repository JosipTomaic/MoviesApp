using MoviesApp.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Model
{
    public class MovieDomain: IMovieDomain
    {
        public Guid Id { get; set; }

        public int TmbdId { get; set; }

        public string OriginalTitle { get; set; }

        public double Popularity { get; set; }

        public List<int> GenreIds { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateCreated { get; set; }

        public virtual IEnumerable<IMovieGenreDomain> MovieGenres { get; set; }
        public virtual IEnumerable<ICrewMemberMovieCreditDomain> CrewMemberMovieCredits { get; set; }

    }
}
