using SkiaSharp;

namespace JosPot.Entities
{
    public class Marker : Entity
    {
        private float width;
        private float height;
        private SKPaint paint;

        public Marker(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            this.width = width;
            this.height = height;
            paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.White,
                StrokeWidth = 0.5f,
                StrokeCap = SKStrokeCap.Round,
                IsAntialias = true
            };
        }

        public override void Draw(SKCanvas c)
        {
            c.DrawRect(X, Y, width, height, paint);
        }

        public override void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}
