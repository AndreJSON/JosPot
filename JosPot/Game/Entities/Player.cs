using System;
using System.Collections.Generic;
using System.Text;
using SkiaSharp;

namespace JosPot.Entities
{
    public class Player : Entity
    {
        private SKPaint paint;
        private SKPath path;
        private float scale;

        public Player(float x, float y, float scale)
        {
            X = x;
            Y = y;
            this.scale = scale;

            paint = new SKPaint()
            {
                IsAntialias = true,
                Style = SKPaintStyle.Fill,
                Color = new SKColor(140, 150, 160),
            };

            path = new SKPath();
            path.MoveTo(0, 0);
            path.LineTo(8, 0);
            path.LineTo(8, 12);
            path.LineTo(0, 12);
            path.LineTo(0, 0);
        }

        public override void Draw(SKCanvas canvas)
        {
            canvas.Save();
            canvas.Translate(X, Y);
            canvas.Scale(scale);
            canvas.DrawPath(path, paint);
            canvas.Restore();
        }

        public override void Move()
        {
        }
    }
}
