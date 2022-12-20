using MoviesApp.Model;
using MoviesApp.Model.Common;
using MoviesApp.Repository.Common;
using MoviesApp.Service.Common;
using Newtonsoft.Json;

namespace MoviesApp.Service
{
    public class TMDBService: ITMDBService
    {
        #region Attributes

        const string TMDB_APIKEY = "51a02ccd852728dfeed48066f7fcf147";
        const string TMDB_URL = "https://api.themoviedb.org/3";

        #endregion Attributes

        #region Constructors

        public TMDBService(
            IMovieRepository movieRepository,
            IGenreRepository genreRepository,
            IMovieGenreRepository movieGenreRepository,
            IMovieCreditRepository movieCreditRepository,
            ICrewMemberRepository crewMemberRepository,
            ICrewMemberMovieCreditRepository crewMemberMovieCreditRepository
        )
        {
            HttpClient = new HttpClient();
            MovieRepository = movieRepository;
            GenreRepository = genreRepository;
            MovieGenreRepository = movieGenreRepository;
            MovieCreditRepository = movieCreditRepository;
            CrewMemberRepository = crewMemberRepository;
            CrewMemberMovieCreditRepository = crewMemberMovieCreditRepository;
        }

        #endregion Constructors

        #region Properties

        protected HttpClient HttpClient { get; set; }

        protected IMovieRepository MovieRepository { get; private set; }

        protected IGenreRepository GenreRepository { get; private set; }

        protected IMovieGenreRepository MovieGenreRepository { get; private set; }

        protected IMovieCreditRepository MovieCreditRepository { get; private set; }

        protected ICrewMemberRepository CrewMemberRepository { get; private set;}

        protected ICrewMemberMovieCreditRepository CrewMemberMovieCreditRepository { get; private set; }

        #endregion Properties

        #region Methods

        public async Task<bool> GetAPIData()
        {
            try
            {
                IEnumerable<IAPIMovie> APIMoviesList = await GetAPIMostPopularMoviesToday();
                IEnumerable<IAPIGenre> APIGenresList = await GetAPIGenres();

                IEnumerable<IGenreDomain> genreDomainList = MapGenres(APIGenresList);
                IEnumerable<IMovieDomain> movieDomainList = MapMovies(APIMoviesList);
                IEnumerable<IMovieGenreDomain> movieGenreList = MapMovieGenres(movieDomainList, genreDomainList);

                await GenreRepository.InsertManyAsync(genreDomainList);
                await MovieRepository.InsertManyAsync(movieDomainList);
                await MovieGenreRepository.InsertManyAsync(movieGenreList);

                IEnumerable<IMovieCreditDomain> movieCreditsList = MovieCreditRepository.GetMovieCredits(); // -> this is a lookup, it is ideal to cache it somewhere to prevent going to DB each time when we need it

                List<ICrewMemberMovieCreditDomain> crewMemberMovieCreditDomains = new List<ICrewMemberMovieCreditDomain>();
                List<ICrewMemberDomain> crewMembersList = await GetAPICrewMembersAndMap(movieDomainList, movieCreditsList, crewMemberMovieCreditDomains);

                await CrewMemberRepository.InsertMany(crewMembersList);
                await CrewMemberMovieCreditRepository.InsertMany(crewMemberMovieCreditDomains);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private async Task<IEnumerable<IAPIMovie>> GetAPIMostPopularMoviesToday()
        {
            try
            {
                IEnumerable<IAPIMovie> APIMoviesList = new List<IAPIMovie>();

                using (var httpRequest = new HttpRequestMessage(new HttpMethod("GET"), $"{TMDB_URL}/trending/movie/day?api_key={TMDB_APIKEY}&page=1"))
                {
                    HttpResponseMessage httpResponseMessage = await HttpClient.SendAsync(httpRequest);
                    var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<APIMovieResult>(jsonResponse);

                    if (response != null)
                    {
                        APIMoviesList = response.Results;
                    }
                }

                return APIMoviesList;
            }
            catch(Exception ex)
            {
                var exception = ex;
                Console.Error.WriteLine(exception.Message);

                return new List<IAPIMovie>();
            }
        }

        private async Task<IEnumerable<IAPIGenre>> GetAPIGenres()
        {
            try
            {
                IEnumerable<IAPIGenre> APIGenresList = new List<IAPIGenre>();

                using (var httpRequest = new HttpRequestMessage(new HttpMethod("GET"), $"{TMDB_URL}/genre/movie/list?api_key={TMDB_APIKEY}&page=1"))
                {
                    HttpResponseMessage httpResponseMessage = await HttpClient.SendAsync(httpRequest);
                    var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<APIGenreResult>(jsonResponse);

                    if (response != null)
                    {
                        APIGenresList = response.Genres;
                    }
                }

                return APIGenresList;
            }
            catch (Exception ex)
            {
                var exception = ex;
                Console.Error.WriteLine(exception.Message);

                return new List<IAPIGenre>();
            }
        }

        private async Task<List<ICrewMemberDomain>> GetAPICrewMembersAndMap(IEnumerable<IMovieDomain> movies, IEnumerable<IMovieCreditDomain> movieCredits, List<ICrewMemberMovieCreditDomain> crewMemberMovieCreditDomains)
        {
            List<ICrewMemberDomain> mappedCrewMembers = new List<ICrewMemberDomain>();
            var actorLookup = movieCredits.FirstOrDefault(movieCreditItem => String.Equals(movieCreditItem.Name, "Actor"));
            var directorLookup = movieCredits.FirstOrDefault(movieCreditItem => String.Equals(movieCreditItem.Name, "Director"));

            foreach (IMovieDomain movie in movies)
            {
                using(var httpRequest = new HttpRequestMessage(new HttpMethod("GET"), $"{TMDB_URL}/movie/{movie.TmbdId}/credits?api_key={TMDB_APIKEY}"))
                {
                    HttpResponseMessage httpResponseMessage = await HttpClient.SendAsync(httpRequest);
                    var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<APIMovieCredit>(jsonResponse);
                    if (response != null)
                    {
                        var directors = response.Crew.Where(crewMember => String.Equals(crewMember.Job, "Director"));
                        var actors = response.Cast;

                        if (directors != null)
                        {
                            foreach (var director in directors)
                            {
                                var existingCrewMember = mappedCrewMembers.FirstOrDefault(crewMember => crewMember.TmdbId == director.Id);

                                ICrewMemberDomain crewMember = new CrewMemberDomain
                                {
                                    Id = existingCrewMember != null ? existingCrewMember.Id : Guid.NewGuid(),
                                    Name = director.Name,
                                    TmdbId = director.Id
                                };

                                if (existingCrewMember == null)
                                {
                                    mappedCrewMembers.Add(crewMember);
                                }

                                crewMemberMovieCreditDomains.Add(new CrewMemberMovieCreditDomain
                                {
                                    Id = Guid.NewGuid(),
                                    CrewMemberId = crewMember.Id,
                                    MovieCreditId = directorLookup.Id,
                                    MovieId = movie.Id
                                });
                            }
                        }

                        if (actors != null)
                        {
                            foreach (var actor in actors)
                            {
                                var existingCrewMember = mappedCrewMembers.FirstOrDefault(crewMember => crewMember.TmdbId == actor.Id);
                                
                                ICrewMemberDomain crewMember = new CrewMemberDomain
                                {
                                    Id = existingCrewMember != null ? existingCrewMember.Id : Guid.NewGuid(),
                                    Name = actor.Name,
                                    TmdbId = actor.Id
                                };

                                if (existingCrewMember == null)
                                {
                                    mappedCrewMembers.Add(crewMember);
                                }

                                crewMemberMovieCreditDomains.Add(new CrewMemberMovieCreditDomain
                                {
                                    Id = Guid.NewGuid(),
                                    CrewMemberId = crewMember.Id,
                                    MovieCreditId = actorLookup.Id,
                                    MovieId = movie.Id
                                });
                            }
                        }
                    }
                }
            }

            return mappedCrewMembers;
        }

        private IEnumerable<IMovieDomain> MapMovies(IEnumerable<IAPIMovie> APIMoviesList)
        {
            try
            {
                return APIMoviesList.Select(movie =>
                {
                    IMovieDomain movieDomain = new MovieDomain
                    {
                        Id = Guid.NewGuid(),
                        DateCreated = DateTime.Now,
                        OriginalTitle = movie.OriginalTitle,
                        GenreIds = movie.GenreIds.ToList(),
                        Popularity = movie.Popularity,
                        ReleaseDate = movie.ReleaseDate,
                        TmbdId = movie.TmbdId
                    };

                    return movieDomain;
                }).ToList();
            }catch (Exception ex)
            {
                return default;
            }
        }

        private IEnumerable<IGenreDomain> MapGenres(IEnumerable<IAPIGenre> APIGenresList)
        {
            return APIGenresList.Select(genre =>
            {
                IGenreDomain genreDomain = new GenreDomain
                {
                    Id = Guid.NewGuid(),
                    Name = genre.Name,
                    TmdbId = genre.Id
                };

                return genreDomain;
            }).ToList();
        }

        private IEnumerable<IMovieGenreDomain> MapMovieGenres(IEnumerable<IMovieDomain> movies, IEnumerable<IGenreDomain> genreDomainList)
        {
            IEnumerable<IMovieGenreDomain> movieGenres = new List<IMovieGenreDomain>();
            
            foreach(var movieDomain in movies)
            {
                var movieGenreCombinations = genreDomainList.Where(genre => movieDomain.GenreIds.Contains(genre.TmdbId)).Select(genre => new MovieGenreDomain
                {
                    GenreId = genre.Id,
                    Id = Guid.NewGuid(),
                    MovieId = movieDomain.Id
                });

                movieGenres = movieGenres.Concat(movieGenreCombinations);
            }

            return movieGenres.ToList();
        }

        #endregion Methods
    }
}
