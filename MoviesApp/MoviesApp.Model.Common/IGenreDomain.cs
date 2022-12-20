using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Model.Common
{
    public interface IGenreDomain
    {
        Guid Id { get; set; }
        int TmdbId { get; set; }
        string Name { get; set; }

        ICollection<IMovieGenreDomain> MovieGenres { get; set; }
    }
}
