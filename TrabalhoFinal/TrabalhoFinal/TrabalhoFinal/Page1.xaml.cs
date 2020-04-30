using System;
using Xamarin.Forms;
using static TrabalhoFinal.Modal.Filmes;
using TrabalhoFinal.ViewModal;
using Xamarin.Forms.Xaml;
using TrabalhoFinal.Modal;
using static TrabalhoFinal.ViewModal.ListaFilmesViewModal;
using System.Collections.Generic;

namespace TrabalhoFinal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
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