using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.DAL.Models
{
    [Table("CrewMembereMovieCredit")]
    public class CrewMemberMovieCredit
    {
        public Guid Id { get; set; }
        public Guid CrewMemberId { get; set; }
        public Guid MovieCreditId { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public MovieCredit MovieCredit { get; set; }
        public CrewMember CrewMember { get; set; }
    }
}
