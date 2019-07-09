using System;
using System.Collections.Generic;
using System.Text;
using JosPot.Entities;
using SkiaSharp;

namespace JosPot
{
    public class GameState
    {
        public float X;
        public float Y;
        private float width;
        private float height;
        private float scale;
        private List<Entity> markers;
        private Player player;

        public GameState(float x, float y, float width, float height, float scale)
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

            player = new Player(46, 120, 1);
        }

        public void Draw(SKCanvas c)
        {
            c.Save();
            c.Translate(X, Y);
            c.Scale(scale);
            player.Draw(c);
            foreach (var m in markers)
            {
                m.Draw(c);
            }
            c.Restore();
        }
    }
}
