using System.Collections.Generic;
using System.Linq;
using SkiaSharp;
using JosPot.Entities;

namespace JosPot
{
    public class GameBackground
    {
        public float X;
        public float Y;
        private float width;
        private float height;
        private float scale;
        private List<Entity> markers;
        private List<Entity> stars;

        public GameBackground(float x, float y, float width, float height, float scale)
        {
            X = x;
            Y = y;
            this.width = width;
            this.height = height;
            this.scale = scale;

            markers = new List<Entity>
            {
                new Marker(X, Y, width, height)
            };

            stars = new List<Entity>();
            var factory = new EntityFactory();
            stars.Add(factory.CreateStar());
        }

        public void Draw(SKCanvas c)
        {
            c.Save();
            c.Translate(X, Y);
            c.Scale(scale);
            foreach (var e in markers.Concat(stars))
            {
                e.Draw(c);
            }
            c.Restore();
        }
    }
}
