using ListagemNotas.Models;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListagemNotas
{
    public partial class App : Application
    {       

        public static string FolderPath { get; set; }
        public static bool IsUserLoggedIn { get; set; }
        public static User CurrentUser { get; set; }
        public App()
        {
            InitializeComponent();
            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            IsUserLoggedIn = false;
            CurrentUser = null;
            MainPage = new NavigationPage ( new Login());           
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
