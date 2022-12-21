using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Model.Common
{
    public interface IMovieResult
    {
        IEnumerable<IMovieDomain> Movies { get; set; }
        int TotalPages { get; set; }
    }
}
