using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.DAL.Models
{
    [Table("CrewMember")]
    public class CrewMember
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TmdbId { get; set; }
        public IEnumerable<CrewMemberMovieCredit> CrewMemberMovieCredits { get; set; }
    }
}
