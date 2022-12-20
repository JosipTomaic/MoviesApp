using MoviesApp.DAL;
using MoviesApp.DAL.Models;
using MoviesApp.Model.Common;
using MoviesApp.Repository.Common;

namespace MoviesApp.Repository
{
    public class GenreRepository: IGenreRepository
    {
        #region Constructor

        public GenreRepository(MoviesAppContext context)
        {
            Context = context;
        }

        #endregion Constructors

        #region Properties

        protected MoviesAppContext Context { get; private set; }

        #endregion Properties

        #region Methods

        public async Task<bool> InsertManyAsync(IEnumerable<IGenreDomain> genres)
        {
            try
            {
                List<Genre> genreEntitiesList = new List<Genre>();

                foreach(IGenreDomain genreDomain in genres)
                {
                    Genre genre = new Genre
                    {
                        Id = genreDomain.Id,
                        Name = genreDomain.Name,
                        TmdbId = genreDomain.TmdbId
                    };

                    genreEntitiesList.Add(genre);
                }

                await Context.Genres.AddRangeAsync(genreEntitiesList);
                Context.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        #endregion Methods
    }
}
