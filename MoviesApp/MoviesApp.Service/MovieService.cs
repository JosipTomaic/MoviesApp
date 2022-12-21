using MoviesApp.Model.Common;
using MoviesApp.Repository.Common;
using MoviesApp.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Service
{
    public class MovieService : IMovieService
    {
        private IMovieRepository MovieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            MovieRepository = movieRepository;
        }

        public async Task<IMovieResult> GetAll(string searchTerm, int pageNumber)
        {
            return await MovieRepository.GetAll(searchTerm, pageNumber);
        }
    }
}
