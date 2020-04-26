using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal.Modal;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static TrabalhoFinal.Modal.Filme;

namespace TrabalhoFinal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public int Count = 0;
        public short Counter = 0;
        public int SlidePosition = 0;
        string heightList;
        int heightRowsList = 90;
        private const string Url = "https://api.themoviedb.org/3/movie/228150-fury?api_key=195f09ffbfbedc80a969bd3eeda78b38";
        // This handles the Web data request
        private HttpClient _client = new HttpClient();

        // public string Replace(string target, string replacement);
        public Page2(string data)
        {
            InitializeComponent();

            string dados = data.ToLower();

            string filme_id = dados.Replace(' ', '-');

            // GetJSON(filme_id);
            OnGetList(filme_id);
        }

        protected async void OnGetList(string filme_id)
        {
            try
            {
                var client = new System.Net.Http.HttpClient();
                var response = await client.GetAsync("https://api.themoviedb.org/3/movie/"+filme_id+"?api_key=195f09ffbfbedc80a969bd3eeda78b38");
                string json = await response.Content.ReadAsStringAsync();
                var tr = JsonConvert.DeserializeObject<Filme>(json);

                Original_title.BindingContext = tr.Original_title;
                Poster_path.BindingContext = "https://image.tmdb.org/t/p/w300_and_h450_bestv2/"+tr.Poster_path;
                Backdrop_path.BindingContext = "https://image.tmdb.org/t/p/w533_and_h300_bestv2/"+tr.Backdrop_path;
                Overview.BindingContext = tr.Overview;

                //Then finally we attach the List to the ListView. Seems Simple :)


                // Content = myList;
            }
            catch (InvalidCastException e)
            {
                throw e;
            }         
             
        }
        /*
        public async void GetJSON(string filme_id)
        {
            try
            {
                var client = new System.Net.Http.HttpClient();
                var response = await client.GetAsync("https://api.themoviedb.org/3/movie/"+filme_id+"?api_key=195f09ffbfbedc80a969bd3eeda78b38");
                string json = await response.Content.ReadAsStringAsync();
                //Filme filme = new Filme();
                RootObject rootObject = new RootObject();
                if (json != "")
                {
                    rootObject = JsonConvert.DeserializeObject<RootObject>(json);
                }
                teste.BindingContext = rootObject;
                filmesList.ItemsSource = rootObject.Results;

                Content = filmesList;
            }
            catch (InvalidCastException e)
            {
                throw e;
            }
            //ProgressLoader.IsVisible = false;
        }
        */
    }
}