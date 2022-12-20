using MoviesApp.DAL;
using MoviesApp.DAL.Models;
using MoviesApp.Model.Common;
using MoviesApp.Repository.Common;

namespace MoviesApp.Repository
{
    public class CrewMemberRepository: ICrewMemberRepository
    {
        #region Constructors

        public CrewMemberRepository
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

        public async Task<bool> InsertMany(IEnumerable<ICrewMemberDomain> crewMembers)
        {
            try
            {
                List<CrewMember> crewMemberEntitiesList = new List<CrewMember>();

                foreach(ICrewMemberDomain crewMemberDomain in crewMembers)
                {
                    CrewMember crewMember = new CrewMember
                    {
                        Id = crewMemberDomain.Id,
                        Name = crewMemberDomain.Name,
                        TmdbId = crewMemberDomain.TmdbId
                    };

                    crewMemberEntitiesList.Add(crewMember);
                }

                await Context.CrewMembers.AddRangeAsync(crewMemberEntitiesList);
                await Context.SaveChangesAsync();
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
