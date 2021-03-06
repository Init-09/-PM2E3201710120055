
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;
using ExamenPM02.ViewModels;
using ExamenPM02.Models;

namespace ExamenPM02.ViewModels
{
     public class ViewModelData : INotifyPropertyChanged
    {
        LogicData articulosMVVM = new LogicData();
        public event PropertyChangedEventHandler PropertyChanged;

        private int id_pago;
        public int Id_Pago
        {
            get { return id_pago; }
            set
            {
                id_pago = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Id_Pago"));
            }
        }

        private double monto;
        public double Monto
        {
            get { return monto; }
            set
            {
                monto = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Monto"));
            }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                descripcion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Descripcion"));
            }
        }


        private string base64;
        public string Imagen
        {
            get { return base64; }
            set
            {
                base64 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Imagen"));
            }
        }

        private DateTime dueDate = DateTime.Now;
        public DateTime DueDate
        {
            get { return dueDate; }
            set
            {
                dueDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DueDate"));
            }
        }

        private List<Data> taskList;
        public List<Data> TaskList
        {
            get { return taskList; }
            set
            {

                taskList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TaskList"));
            }
        }
        public Command cmdAddTask { get; set; }
        public Command cmdAddTask1 { get; set; }
        public Command cmdeliminar { get; set; }
        public ViewModelData()
        {
            cmdAddTask = new Command(AddTask);
            cmdAddTask1 = new Command(deleteAsync1);
        
            getTask();
        }

        public ICommand EliminarCommand
        {
            get
            {
                return new RelayCommand(deleteAsync1);
            }
        }

        private async void AddTask(object obj)
        {
            var r = await App.BaseDatos.SaveTaskAsync(new Data
            {
                Descripcion = descripcion,
                Monto = Monto,
                Fecha = DueDate,
                Imagen = Imagen,
            });

            getTask();

            await Application.Current.MainPage.DisplayAlert("Alert", "Informacion Guardada", "OK");
        }

        

        private async void deleteAsync1()
        {
            if (!string.IsNullOrEmpty(id_pago.ToString()))
            {
                //Get Person

                var person = await App.BaseDatos.GetItemAsync(Convert.ToInt32(id_pago.ToString()));
                if (person != null)
                {
                    //Delete Person
                    await App.BaseDatos.deleteAsync(person);
                    await Application.Current.MainPage.DisplayAlert("Success", "Person Deleted", "OK");

                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Required", "Please Enter PersonID", "OK");
            }
        }

        public async void getTask()
        {
            TaskList = await App.BaseDatos.GetTaskAsync();
        }

    }
}
