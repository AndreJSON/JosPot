using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkiaSharp;

namespace JosPot
{
    public class GameOverlay
    {
        public float X;
        public float Y;
        private float width;
        private float height;
        private float scale;
        private SKPaint paint;
        private List<DateTime> frames = new List<DateTime>();
        private List<DateTime> ticks = new List<DateTime>();

        public GameOverlay(float x, float y, float width, float height, float scale)
        {
            X = x;
            Y = y;
            this.width = width;
            this.height = height;
            this.scale = scale;
            paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.White,
                StrokeWidth = 0.5f,
                StrokeCap = SKStrokeCap.Round,
                IsAntialias = true,
                Typeface = SKTypeface.FromFamilyName("roboto") //Funkar inte
            };
        }

        public void Draw(SKCanvas c)
        {
            c.Save();
            c.Translate(X, Y);
            c.Scale(scale);
            DrawFPS(c);
            c.Restore();
        }

        private void DrawFPS(SKCanvas c)
        {
            frames = frames.Where(f => f > DateTime.Now.AddSeconds(-1)).ToList();
            frames.Add(DateTime.Now);
            c.DrawText(frames.Count.ToString(), 5, 10, paint);
            c.DrawText(ticks.Count.ToString(), 5, 20, paint);
        }

        public void Tick()
        {
            ticks = ticks.Where(t => t > DateTime.Now.AddSeconds(-1)).ToList();
            ticks.Add(DateTime.Now);
        }
    }
}
