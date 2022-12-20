using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.DAL.Models
{
    [Table("MovieCredit")]
    public class MovieCredit
    {
        public MovieCredit()
        {
            CrewMemberMovieCredits = new HashSet<CrewMemberMovieCredit>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CrewMemberMovieCredit>? CrewMemberMovieCredits { get; set; }
    }
}
