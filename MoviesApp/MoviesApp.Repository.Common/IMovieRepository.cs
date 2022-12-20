using MoviesApp.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Repository.Common
{
    public interface IMovieRepository
    {
        Task<bool> InsertManyAsync(IEnumerable<IMovieDomain> movies);

        Task<IEnumerable<IMovieDomain>> GetAll(string searchTerm);
    }
}
