using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.DAL.Models
{
    [Table("Movie")]
    public class Movie
    {
        public Guid Id { get; set; }

        public int TmbdId { get; set; }

        public string OriginalTitle { get; set; }

        public double Popularity { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateCreated { get; set; }

        public virtual IEnumerable<MovieGenre> MovieGenres { get; set;}
        public virtual IEnumerable<CrewMemberMovieCredit> CrewMemberMovieCredits { get; set;}
    }
}
