using System.Collections.Generic;
using Newtonsoft.Json;

namespace TrabalhoFinal.Modal
{
    class Filmes
    {

        [JsonProperty("poster_path")]
        public string Poster_path { get; set; }

        [JsonProperty("original_title")]
        public string Original_title { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        public string FullPathImage
        {
            get
            {
                return "https://image.tmdb.org/t/p/w300_and_h450_bestv2/"+Poster_path;
            }
        }

        public string NomeFilme
        {
            get
            {
                return "Nome: "+ Original_title;
            }
        }

        public string DescricaoFilme
        {
            get
            {
                return "Descrição: " + Overview;
            }
        }

        public string CodigoFilme
        {
            get
            {
                return Id+"-"+Original_title;
            }
        }

        public class RootObject
        {
            public List<Filmes> Results { get; set; }
        }
    }
}
