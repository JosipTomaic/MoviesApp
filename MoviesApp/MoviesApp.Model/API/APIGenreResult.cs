using MoviesApp.Common;
using MoviesApp.Model.Common;
using Newtonsoft.Json;

namespace MoviesApp.Model
{
    public class APIGenreResult: IAPIGenreResult
    {
        [JsonConverter(typeof(MovieAppJsonConvert<IEnumerable<APIGenre>>))]
        public IEnumerable<IAPIGenre> Genres { get; set; }
    }
}
