using Examen_Movil.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExamenPM02.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListView : ContentPage
    {
        public ListView()
        {
            InitializeComponent();
        }

        private async void ListaPrecios_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Models.Data item = (Models.Data)e.Item;
            /// await DisplayAlert("Elemento Tocado " , "Descripcion: " + item.Descripcion, "Ok");

            var page = new UpdateView();
           page.BindingContext = item;
           await Navigation.PushModalAsync(page);
        }
    }
    

}