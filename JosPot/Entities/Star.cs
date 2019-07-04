using System;
using System.Collections.Generic;
using System.Text;
using SkiaSharp;

namespace JosPot.Entities
{
    public class Star : Entity
    {
        private SKPaint paint;
        private SKPath path;
        private float scale;

        public Star(float scale)
        {
            this.scale = scale;

            paint = new SKPaint() {
                IsAntialias = true,
                Style = SKPaintStyle.Fill,
                Color = new SKColor(255,255,255,(byte)(255*0.85)),
            };

            path = new SKPath();
            path.MoveTo(0, 0);
            path.LineTo(1, 2);
            path.LineTo(3, 3);
            path.LineTo(1, 4);
            path.LineTo(0, 6);
            path.LineTo(-1, 4);
            path.LineTo(-3, 3);
            path.LineTo(-1, 2);
            path.LineTo(0, 0);
        }

        public override void Draw(SKCanvas canvas)
        {
            canvas.Translate(3, 3);
            canvas.Scale(scale);
            canvas.DrawPath(path, paint);
        }
    }
}
