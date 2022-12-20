using MoviesApp.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Service.Common
{
    public interface IMovieService
    {
        Task<IEnumerable<IMovieDomain>> GetAll(string searchTerm);
    }
}
