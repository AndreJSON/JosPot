using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace JosPot
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private static readonly int FPS = 60;
        private static readonly int TPS = 60;

        public MainPage()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(1f / FPS), () =>
            {
                CanvasView.InvalidateSurface();
                return true;
            });

            Device.StartTimer(TimeSpan.FromSeconds(1f / FPS), () =>
            {
                GameTick();
                return true;
            });
        }

        private void GameTick()
        {
            //Stuff for one game tick
        }

        private readonly SKPaint WhiteStrokePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.White,
            StrokeWidth = 1,
            StrokeCap = SKStrokeCap.Round,
            IsAntialias = true
        };

        private void DrawBackground(SKCanvas c, float width, float height)
        {
            c.Clear(SKColors.Black);
            c.DrawRect(0, 0, width, height, WhiteStrokePaint);
        }

        private void DrawGameArea(SKCanvas c, float width, float height)
        {
            c.DrawRect(0, 0, width, height, WhiteStrokePaint);
            c.DrawCircle(7, 7, 2, WhiteStrokePaint);
        }

        private void DrawTopBar(SKCanvas c, float width, float height)
        {
            c.DrawRect(0, 0, width, height, WhiteStrokePaint);
            c.DrawCircle(7, 7, 2, WhiteStrokePaint);
        }

        private void DrawMenu(SKCanvas c, float width, float height)
        {
            c.DrawRect(0, 0, width, height, WhiteStrokePaint);
            c.DrawCircle(7, 7, 2, WhiteStrokePaint);
            //Topdelen av menyn kanske kan ritas men nån slags bezierkurva
        }

        private void CanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKCanvas canvas = e.Surface.Canvas;
            int backgroundWidth = e.Info.Width;
            int backgroundHeight = e.Info.Height;
            int gameWidth = backgroundWidth;
            int gameHeight = (backgroundWidth * 4) / 3;
            int topWidth = backgroundWidth;
            int topHeight = (int)(backgroundWidth * 0.15);
            int menuWidth = backgroundWidth;
            int menuHeight = backgroundHeight - topHeight - gameHeight;

            canvas.Save();
            canvas.Translate(0, 0);
            canvas.Scale(backgroundWidth / 100f);
            DrawBackground(canvas, 100f, ((float)backgroundHeight/backgroundWidth) * 100);
            canvas.Restore();

            canvas.Save();
            canvas.Translate(0, topHeight);
            canvas.Scale(backgroundWidth / 100f);
            DrawGameArea(canvas, 100f, ((float)gameHeight / gameWidth) * 100);
            canvas.Restore();

            canvas.Save();
            canvas.Translate(0, 0);
            canvas.Scale(backgroundWidth / 100f);
            DrawTopBar(canvas, 100f, ((float)topHeight / topWidth) * 100);
            canvas.Restore();

            canvas.Save();
            canvas.Translate(0, topHeight + gameHeight);
            canvas.Scale(backgroundWidth / 100f);
            DrawMenu(canvas, 100f, ((float)menuHeight / menuWidth) * 100);
            canvas.Restore();
        }
    }
}
