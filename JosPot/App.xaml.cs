using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JosPot
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage()
            {
                BackgroundColor = Color.Red,
            };
            MainPage.SetValue(NavigationPage.BarBackgroundColorProperty, Color.Black);
            MainPage.SetValue(NavigationPage.BarTextColorProperty, Color.Black);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
