using MoviesApp.DAL;
using MoviesApp.DAL.Models;
using MoviesApp.Model;
using MoviesApp.Model.Common;
using MoviesApp.Repository.Common;

namespace MoviesApp.Repository
{
    public class MovieCreditRepository : IMovieCreditRepository
    {
        #region Constructors

        public MovieCreditRepository(
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

        public IEnumerable<IMovieCreditDomain> GetMovieCredits()
        {
            var movieCreditEntities = Context.MovieCredits.ToList();
            List<IMovieCreditDomain> movieCredits = new List<IMovieCreditDomain>();

            foreach(MovieCredit movieCredit in movieCreditEntities)
            {
                IMovieCreditDomain movieCreditDomain = new MovieCreditDomain();
                movieCreditDomain.Id = movieCredit.Id;
                movieCreditDomain.Name = movieCredit.Name;
                movieCredits.Add(movieCreditDomain);
            }

            return movieCredits;
        }

        #endregion Methods
    }
}
