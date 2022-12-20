using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Model.Common
{
    public interface IMovieGenreDomain
    {
        Guid Id { get; set; }
        Guid MovieId { get; set; }
        Guid GenreId { get; set; }

        IMovieDomain Movie { get; set; }
        IGenreDomain Genre { get; set; }
    }
}
