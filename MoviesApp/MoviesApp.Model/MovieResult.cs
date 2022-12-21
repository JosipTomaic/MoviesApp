using MoviesApp.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Model
{
    public class MovieResult: IMovieResult
    {
        public IEnumerable<IMovieDomain> Movies { get; set; }
        public int TotalPages { get; set; }
    }
}
