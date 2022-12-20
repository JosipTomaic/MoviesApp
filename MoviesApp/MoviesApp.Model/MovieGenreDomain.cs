using MoviesApp.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Model
{
    public class MovieGenreDomain: IMovieGenreDomain
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Guid GenreId { get; set; }

        public virtual IMovieDomain Movie { get; set; }
        public virtual IGenreDomain Genre { get; set; }
    }
}
