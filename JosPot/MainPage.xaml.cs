using System;
using System.ComponentModel;
using Xamarin.Forms;
using SkiaSharp.Views.Forms;

namespace JosPot
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private static GameManager Game;
        private DateTime previous = DateTime.Now;
        private TimeSpan lag = TimeSpan.Zero;
        private TimeSpan update_interval = TimeSpan.FromMilliseconds(1000f/1000);

        public MainPage()
        {
            InitializeComponent();
        }

        private void CanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            if (Game == null)
                Game = new GameManager(e.Info.Width, e.Info.Height);

            var current = DateTime.Now;
            lag += current - previous;
            previous = current;

            var ticksThisDraw = 0;
            while (lag >= update_interval)
            {
                Game.Tick();
                lag -= update_interval;

                ticksThisDraw++;
                if (ticksThisDraw >= 40)
                    lag = TimeSpan.Zero;
            }

            Game.Draw(e.Surface.Canvas);

            CanvasView.InvalidateSurface();
        }
    }
}
