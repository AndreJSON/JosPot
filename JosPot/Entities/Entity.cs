using System;
using System.Collections.Generic;
using System.Text;
using SkiaSharp;

namespace JosPot
{
    public abstract class Entity
    {
        public abstract void Draw(SKCanvas canvas);
    }
}
