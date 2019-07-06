using SkiaSharp;

namespace JosPot
{
    public abstract class Entity
    {
        public float X { get; set; }
        public float Y { get; set; }
        public abstract void Draw(SKCanvas c);
    }
}
