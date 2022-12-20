using Microsoft.EntityFrameworkCore;
using MoviesApp.DAL;
using MoviesApp.DAL.Models;
using MoviesApp.Model;
using MoviesApp.Model.Common;
using MoviesApp.Repository.Common;

namespace MoviesApp.Repository
{
    public class MovieRepository: IMovieRepository
    {
        #region Constructors

        public MovieRepository(MoviesAppContext context)
        {
            Context = context;
        }

        #endregion Constructors

        #region Properties

        protected MoviesAppContext Context { get; private set; }

        #endregion Properties

        #region Methods

        public async Task<bool> InsertManyAsync(IEnumerable<IMovieDomain> movies)
        {
            try
            {
                List<Movie> movieEntitiesList = new List<Movie>();

                foreach(IMovieDomain movieDomain in movies)
                {
                    Movie movie = new Movie
                    {
                        Id = movieDomain.Id,
                        DateCreated = DateTime.Now,
                        OriginalTitle = movieDomain.OriginalTitle,
                        Popularity = movieDomain.Popularity,
                        ReleaseDate = movieDomain.ReleaseDate,
                        TmbdId = movieDomain.TmbdId
                    };

                    movieEntitiesList.Add(movie);
                }

                await Context.Movies.AddRangeAsync(movieEntitiesList);
                Context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<IMovieDomain>> GetAll(string searchTerm)
        {
            List<Movie> movies = new List<Movie>();
            if (String.IsNullOrWhiteSpace(searchTerm))
            {
                movies = Context.Movies
                    .Include(movie => movie.MovieGenres).ThenInclude(genre => genre.Genre)
                    .Include(movie => movie.CrewMemberMovieCredits).ThenInclude(cmmc => cmmc.CrewMember)
                    .Include(movie => movie.CrewMemberMovieCredits).ThenInclude(cmmc => cmmc.MovieCredit).ToList();
            }
            else
            {
                movies = Context.Movies
                    .Include(movie => movie.MovieGenres).ThenInclude(genre => genre.Genre)
                    .Include(movie => movie.CrewMemberMovieCredits).ThenInclude(cmmc => cmmc.CrewMember)
                    .Include(movie => movie.CrewMemberMovieCredits).ThenInclude(cmmc => cmmc.MovieCredit)
                    .Where(movie => movie.OriginalTitle.ToLower().Contains(searchTerm)).ToList();
            }

            List<IMovieDomain> movieDomains = new List<IMovieDomain>();
            foreach(Movie movie in movies)
            {
                IMovieDomain movieDomain = new MovieDomain
                {
                    Id = movie.Id,
                    DateCreated = movie.DateCreated,
                    OriginalTitle = movie.OriginalTitle,
                    Popularity = movie.Popularity,
                    ReleaseDate = movie.ReleaseDate,
                    TmbdId = movie.TmbdId
                };
                List<IMovieGenreDomain> movieGenres = new List<IMovieGenreDomain>();

                foreach(MovieGenre genre in movie.MovieGenres)
                {
                    IMovieGenreDomain movieGenreDomain = new MovieGenreDomain
                    {
                        GenreId = genre.GenreId,
                        MovieId = genre.MovieId,
                        Id = genre.Id,
                        Genre = new GenreDomain
                        {
                            Id = genre.GenreId,
                            Name = genre.Genre.Name,
                            TmdbId = genre.Genre.TmdbId
                        }
                    };
                    movieGenres.Add(movieGenreDomain);
                }

                movieDomain.MovieGenres = movieGenres;

                List<ICrewMemberMovieCreditDomain> crewMembers = new List<ICrewMemberMovieCreditDomain>();

                foreach(CrewMemberMovieCredit crewMember in movie.CrewMemberMovieCredits)
                {
                    ICrewMemberMovieCreditDomain crewMemberMovieCredit = new CrewMemberMovieCreditDomain
                    {
                        Id = crewMember.Id,
                        CrewMemberId = crewMember.CrewMemberId,
                        MovieCreditId = crewMember.MovieCreditId,
                        CrewMember = new CrewMemberDomain
                        {
                            Id = crewMember.CrewMemberId,
                            Name = crewMember.CrewMember.Name,
                            TmdbId = crewMember.CrewMember.TmdbId
                        },
                        MovieCredit = new MovieCreditDomain
                        {
                            Id = crewMember.MovieCreditId,
                            Name = crewMember.MovieCredit.Name,
                        }
                    };
                    crewMembers.Add(crewMemberMovieCredit);
                }

                movieDomain.CrewMemberMovieCredits = crewMembers;

                movieDomains.Add(movieDomain);
            }

            return movieDomains;
        }

        #endregion Methods
    }
}
