using ExamenPM02.ViewModels;
using ExamenPM02.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExamenPM02
{
    public partial class App : Application
    {
        static LogicData basedatos;

        public static LogicData BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new LogicData(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Movil2Xamarin"));
                }
                return basedatos;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new VistaAgregar());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
