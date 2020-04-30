using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrabalhoFinal.Modal;

namespace TrabalhoFinal.ViewModal
{
    class ListaFilmesViewModal
    { 
        public async Task<RootObject> GetJSON()
        {
            try
            {
                var client = new System.Net.Http.HttpClient();
                var response = await client.GetAsync("https://api.themoviedb.org/3/discover/movie?primary_release_date.gte=2014-09-15&primary_release_date.lte=2014-10-22&api_key=195f09ffbfbedc80a969bd3eeda78b38");
                string json = await response.Content.ReadAsStringAsync();
                RootObject rootObject = new RootObject();
                if (json != "")
                {
                    rootObject = JsonConvert.DeserializeObject<RootObject>(json);
                }

                return rootObject;
            }
            catch (InvalidCastException e)
            {
                throw e;
            }
        } 
        public class RootObject
        {
            public List<Filmes> Results { get; set; }
        }
    }
}
