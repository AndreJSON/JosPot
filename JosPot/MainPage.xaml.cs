using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SkiaSharp.Views.Forms;

namespace JosPot
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private static readonly int FPS = 60;
        private static GameManager Game;

        public MainPage()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(1f / FPS), () =>
            {
                CanvasView.InvalidateSurface();
                return true;
            });
        }

        private void CanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            if (Game == null)
                Game = new GameManager(e.Info.Width, e.Info.Height);

            Game.Tick();
            Game.Draw(e.Surface.Canvas);
        }
    }
}
