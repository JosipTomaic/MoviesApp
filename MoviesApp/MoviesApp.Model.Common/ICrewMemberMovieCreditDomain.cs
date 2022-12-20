using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Model.Common
{
    public interface ICrewMemberMovieCreditDomain
    {
        Guid Id { get; set; }
        Guid CrewMemberId { get; set; }
        Guid MovieCreditId { get; set; }
        Guid MovieId { get; set; }
        IMovieDomain Movie { get; set; }
        IMovieCreditDomain MovieCredit { get; set; }
        ICrewMemberDomain CrewMember { get; set; }
    }
}
