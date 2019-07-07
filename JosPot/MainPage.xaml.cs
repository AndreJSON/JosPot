using System;
using System.ComponentModel;
using Xamarin.Forms;
using SkiaSharp.Views.Forms;
using System.Threading.Tasks;

namespace JosPot
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private static GameManager Game;
        private DateTime previous = DateTime.Now;
        private TimeSpan lag = TimeSpan.Zero;
        private TimeSpan update_interval = TimeSpan.FromMilliseconds(1000f/60);

        public MainPage()
        {
            InitializeComponent();
        }

        private async void GLView_PaintSurface(object sender, SKPaintGLSurfaceEventArgs e)
        {
            if (Game == null)
                Game = new GameManager(e.BackendRenderTarget.Width, e.BackendRenderTarget.Height);

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

            await Task.Delay(10);
            GLView.InvalidateSurface();
        }
    }
}
