using MoviesApp.Common;
using MoviesApp.Model.Common;
using Newtonsoft.Json;

namespace MoviesApp.Model
{
    public class APIMovieResult: IAPIMovieResult
    {
        public int Page { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
        [JsonProperty("total_results")]
        public int TotalResults { get; set; }
        [JsonConverter(typeof(MovieAppJsonConvert<IEnumerable<APIMovie>>))]
        public IEnumerable<IAPIMovie> Results { get; set; }
    }
}
