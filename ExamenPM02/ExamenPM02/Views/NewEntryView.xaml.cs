using ExamenPM02.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExamenPM02.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaAgregar : ContentPage
    {
        private string base64;

        public VistaAgregar()
        {
            InitializeComponent();
        }

        

        private async void btnlista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ListView());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }
        private async void BtnCam_Clicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
                {
                    DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Rear,
                    Directory = "Xamarin",
                    SaveToAlbum = true
                });
                if (photo != null)
                    imgCam.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
                Byte[] imagenByte = null;
                using (var stream = new MemoryStream())
                {
                    photo.GetStream().CopyTo(stream);
                    photo.Dispose();
                    imagenByte = stream.ToArray();
                    base64 = Convert.ToBase64String(imagenByte);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }
        }

        //private async void btneliminar_Clicked(object sender, EventArgs e)
        //{
        //    var _pagos = new Models.Data
        //    {

        //        Id_pago = Convert.ToInt32(this.idpago.Text),
        //        Descripcion = this.description.Text,
        //        Monto = Convert.ToDouble(this.monto.Text),
        //        Fecha = this.DueDate.Date,








        //    };

        //    if (await App.BaseDatos.deleteAsync(_pagos) != 0)
        //        await DisplayAlert("Eliminar Persona", "Persona Eliminada Correctamente", "Ok");
        //    else
        //        await DisplayAlert("Eliminar Persona", "Error al Eliminar Persona!!", "Ok");
        //    //await DisplayAlert // Convert.ToDateTime( this.DueDate.no),


        //}

        //private async void btnactualizar_Clicked(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(idpago.Text))
        //    {
        //        Data person = new Data()
        //        {
        //            Id_pago = Convert.ToInt32(idpago.Text),
        //            Descripcion = description.Text,
        //            Monto = Convert.ToInt32(monto.Text)

        //        };

        //        //Update Person  
        //        await App.BaseDatos.SaveTaskAsync(person);

        //        idpago.Text = string.Empty;
        //        description.Text = string.Empty;

        //        await DisplayAlert("Alert", "Pago Actualizado Correctamente", "OK");

        //    }
        //    else
        //    {
        //        await DisplayAlert("Required", "Please Enter PersonID", "OK");
        //    }
        //}
    }
}