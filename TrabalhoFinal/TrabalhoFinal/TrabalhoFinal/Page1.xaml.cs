using System;
using Newtonsoft.Json;
using Xamarin.Forms;
using static TrabalhoFinal.Modal.Filmes;
using TrabalhoFinal.ViewModal;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrabalhoFinal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            //BindingContext = new ListaFilmesViewModal();
            //ListaFilmesViewModal viewModal = new ListaFilmesViewModal();
            GetJSON();
        }
        public async void GetJSON()
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

                filmesList.ItemsSource = rootObject.Results;

                Content = filmesList;
            }
            catch (InvalidCastException e)
            {
                throw e;
            }
            //ProgressLoader.IsVisible = false;
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            // Navigation.PushAsync(new Pagina2());
            //string data = ((Button)sender).BindingContext as string;

            string data = ((Button)sender).BindingContext.ToString();
            
            
            //string data = (sender as Button).BindingContext as string;

            Navigation.PushAsync(new Page2(data));
        }
    }
}