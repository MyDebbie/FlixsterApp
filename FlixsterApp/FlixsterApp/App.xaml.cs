using FlixsterApp.data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

/// <summary>
/// Name : Mydleyka Dimanche
/// Devoir: 5
/// </summary>
namespace FlixsterApp
{
    public partial class App : Application
    { 
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SplashPage());
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
