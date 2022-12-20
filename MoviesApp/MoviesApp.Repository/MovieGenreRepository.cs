using MoviesApp.DAL;
using MoviesApp.DAL.Models;
using MoviesApp.Model.Common;
using MoviesApp.Repository.Common;

namespace MoviesApp.Repository
{
    public class MovieGenreRepository: IMovieGenreRepository
    {
        #region Constructors

        public MovieGenreRepository(
            MoviesAppContext context
        )
        {
            Context = context;
        }

        #endregion Constructors

        #region Properties

        protected MoviesAppContext Context { get; private set; }

        #endregion Properties

        #region Methods

        public async Task<bool> InsertManyAsync(IEnumerable<IMovieGenreDomain> movieGenres)
        {
            try
            {
                List<MovieGenre> movieGenreEntities = new List<MovieGenre>();

                foreach(IMovieGenreDomain movieGenreDomain in movieGenres)
                {
                    MovieGenre movieGenre = new MovieGenre
                    {
                        Id = movieGenreDomain.Id,
                        GenreId = movieGenreDomain.GenreId,
                        MovieId = movieGenreDomain.MovieId
                    };

                    movieGenreEntities.Add(movieGenre);
                }

                await Context.MovieGenres.AddRangeAsync(movieGenreEntities);
                Context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion Methods
    }
}
