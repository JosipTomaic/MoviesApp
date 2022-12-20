using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Model.Common
{
    public interface IAPIMovie
    {
        int TmbdId { get; set; }

        string OriginalTitle { get; set; }

        double Popularity { get; set; }

        DateTime? ReleaseDate { get; set; }

        IEnumerable<int> GenreIds { get; set; }
    }
}
