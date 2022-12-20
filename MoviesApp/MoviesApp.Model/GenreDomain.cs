using MoviesApp.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Model
{
    public class GenreDomain: IGenreDomain
    {
        public Guid Id { get; set; }
        public int TmdbId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<IMovieGenreDomain> MovieGenres { get; set; }
    }
}
