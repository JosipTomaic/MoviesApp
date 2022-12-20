using MoviesApp.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Model
{
    public class CrewMemberMovieCreditDomain: ICrewMemberMovieCreditDomain
    {
        public Guid Id { get; set; }
        public Guid CrewMemberId { get; set; }
        public Guid MovieCreditId { get; set; }
        public Guid MovieId { get; set; }
        public IMovieDomain Movie { get; set; }
        public IMovieCreditDomain MovieCredit { get; set; }
        public ICrewMemberDomain CrewMember { get; set; }
    }
}
