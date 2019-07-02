using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JosPot
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            button.Clicked += Button_Clicked;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string something = entry.Text;
            if(string.IsNullOrEmpty(something))
                return;
            await DisplayAlert("WAWAWAWA", $"Is '{something}' all you have to say for yourself!?", "Ya");
            label.Text = $"Say something other than '{something}'!";
            entry.Text = string.Empty;
        }
    }
}
