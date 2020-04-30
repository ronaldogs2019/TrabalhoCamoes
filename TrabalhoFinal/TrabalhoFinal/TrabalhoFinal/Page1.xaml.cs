using System;
using Xamarin.Forms;
using TrabalhoFinal.ViewModal;


namespace TrabalhoFinal
{
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            BindingContext = new ListaFilmesViewModal();
            ListaFilmesViewModal viewModal = new ListaFilmesViewModal();
            ListagemDeFilmes.ItemsSource = viewModal.GetJSON().Result.Results;
            Content = ListagemDeFilmes;
        }        
        void Button_Clicked(object sender, EventArgs e)
        {
            string filme_id = ((Button)sender).BindingContext.ToString();
            Navigation.PushAsync(new Page2(filme_id));
        }
    }
}