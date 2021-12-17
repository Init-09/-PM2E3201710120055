using ExamenPM02;
using ExamenPM02.Models;
using ExamenPM02.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen_Movil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateView : ContentPage
    {
        private string imageBase64;


        public UpdateView()
        {
            InitializeComponent();
            img.Source = Xamarin.Forms.ImageSource.FromStream(
               () => new MemoryStream(Convert.FromBase64String(imageBase64)));
        }
        private async void btneliminar_Clicked(object sender, EventArgs e)
        {
            var _pagos = new Data
            {

                Id_pago = Convert.ToInt32(this.idpago.Text),
                Descripcion = this.description.Text,
                Monto = Convert.ToDouble(this.monto.Text),
                Fecha = this.DueDate.Date,








            };

            if (await App.BaseDatos.deleteAsync(_pagos) != 0)
            {
                await DisplayAlert("Eliminar Persona", "Persona Eliminada Correctamente", "Ok");
                await Navigation.PushModalAsync(new ExamenPM02.Views.ListView());

            }
            else
                await DisplayAlert("Eliminar Persona", "Error al Eliminar Persona!!", "Ok");
            //await DisplayAlert // Convert.ToDateTime( this.DueDate.no),


        }

        private async void btnactualizar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(idpago.Text))
            {
                Data person = new Data()
                {
                    Id_pago = Convert.ToInt32(idpago.Text),
                    Descripcion = description.Text,
                    Monto = Convert.ToInt32(monto.Text)

                };

                //Update Person  
                await App.BaseDatos.SaveTaskAsync(person);

                idpago.Text = string.Empty;
                description.Text = string.Empty;

                await DisplayAlert("Alert", "Pago Actualizado Correctamente", "OK");

            }
            else
            {
                await DisplayAlert("Required", "Please Enter PersonID", "OK");
            }
        }
         private async void btnlista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ExamenPM02.Views.ListView());
        }
    }
}