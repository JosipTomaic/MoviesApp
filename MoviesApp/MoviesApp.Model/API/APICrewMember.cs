using MoviesApp.Model.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Model
{
    public class APICrewMember: IAPICrewMember
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("original_name")]
        public string? Name { get; set; }

        public double Popularity { get; set; }

        [JsonProperty("job")]
        public string? Job { get; set; }
    }
}
