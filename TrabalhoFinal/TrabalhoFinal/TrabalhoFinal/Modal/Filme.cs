using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrabalhoFinal.Modal
{
    class Filme
    {
        [JsonProperty("poster_path")]
        public string Poster_path { get; set; }

        [JsonProperty("backdrop_path")]
        public string Backdrop_path { get; set; }

        [JsonProperty("original_title")]
        public string Original_title { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

    }
}
