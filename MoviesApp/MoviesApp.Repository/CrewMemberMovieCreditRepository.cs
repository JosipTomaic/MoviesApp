using Microsoft.EntityFrameworkCore;
using MoviesApp.DAL;
using MoviesApp.DAL.Models;
using MoviesApp.Model.Common;
using MoviesApp.Repository.Common;

namespace MoviesApp.Repository
{
    public class CrewMemberMovieCreditRepository: ICrewMemberMovieCreditRepository
    {
        #region Constructors

        public CrewMemberMovieCreditRepository
        (
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

        public async Task<bool> InsertMany(IEnumerable<ICrewMemberMovieCreditDomain> crewMemberMovieCredits)
        {
            try
            {
                List<CrewMemberMovieCredit> crewMemberMovieCreditEntitiesList = new List<CrewMemberMovieCredit>();

                foreach(ICrewMemberMovieCreditDomain crewMemberMovieCreditDomain in crewMemberMovieCredits)
                {
                    CrewMemberMovieCredit crewMemberMovieCredit = new CrewMemberMovieCredit
                    {
                        Id = crewMemberMovieCreditDomain.Id,
                        CrewMemberId = crewMemberMovieCreditDomain.CrewMemberId,
                        MovieCreditId = crewMemberMovieCreditDomain.MovieCreditId,
                        MovieId = crewMemberMovieCreditDomain.MovieId
                    };

                    crewMemberMovieCreditEntitiesList.Add(crewMemberMovieCredit);
                }
                await Context.CrewMemberMovieCredits.AddRangeAsync(crewMemberMovieCreditEntitiesList);
                await Context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                return false;
            }
        }

        #endregion Methods
    }
}
