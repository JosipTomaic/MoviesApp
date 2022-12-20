using MoviesApp.Common;
using MoviesApp.Model.Common;
using Newtonsoft.Json;

namespace MoviesApp.Model
{
    public class APIMovieCredit: IAPIMovieCredit
    {
        [JsonProperty("cast")]
        [JsonConverter(typeof(MovieAppJsonConvert<IEnumerable<APICrewMember>>))]
        public IEnumerable<IAPICrewMember> Cast { get; set; }

        [JsonProperty("crew")]
        [JsonConverter(typeof(MovieAppJsonConvert<IEnumerable<APICrewMember>>))]
        public IEnumerable<IAPICrewMember> Crew { get; set; }
    }
}
