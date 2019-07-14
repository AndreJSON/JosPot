using System;
using System.Collections.Generic;
using System.Text;
using SkiaSharp;
using JosPot.Entities;

namespace JosPot
{
    public class GameTopBar
    {
        public float X;
        public float Y;
        private float width;
        private float height;
        private float scale;
        private List<Entity> markers;

        public GameTopBar(float x, float y, float width, float height, float scale)
        {
            X = x;
            Y = y;
            this.width = width;
            this.height = height;
            this.scale = scale;

            markers = new List<Entity>
            {
                //new Marker(0, 0, width, height)
            };
        }

        public void Draw(SKCanvas c)
        {
            c.Save();
            c.Translate(X, Y);
            c.Scale(scale);
            foreach (var m in markers)
            {
                m.Draw(c);
            }
            c.Restore();
        }
    }
}
