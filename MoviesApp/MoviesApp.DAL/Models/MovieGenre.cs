using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.DAL.Models
{
    [Table("MovieGenre")]
    public class MovieGenre
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Guid GenreId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
