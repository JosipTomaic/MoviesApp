using MoviesApp.Model.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Model
{
    public class APIMovie: IAPIMovie
    {
        [JsonProperty("id")]
        public int TmbdId { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        public double Popularity { get; set; }

        [JsonProperty("release_date")]
        public DateTime? ReleaseDate { get; set; }

        [JsonProperty("genre_ids")]
        public IEnumerable<int> GenreIds { get; set; }
    }
}
