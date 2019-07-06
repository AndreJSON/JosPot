﻿using System;
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
        private List<Marker> markers;

        public GameState(float x, float y, float width, float height, float scale)
        {
            X = x;
            Y = y;
            this.width = width;
            this.height = height;
            this.scale = scale;

            markers = new List<Marker>
            {
                new Marker(X, Y, width, height)
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
