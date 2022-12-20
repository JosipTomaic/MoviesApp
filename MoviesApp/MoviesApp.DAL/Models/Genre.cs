using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.DAL.Models
{
    [Table("Genre")]
    public class Genre
    {
        public Guid Id { get; set; }
        public int TmdbId { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<MovieGenre> MovieGenres { get; set;}
    }
}
