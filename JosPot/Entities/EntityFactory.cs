using System;

namespace JosPot.Entities
{
    public class EntityFactory
    {
        public static Star CreateStar(float fromX, float toX, float fromY, float toY)
        {
            return new Star(Utils.Rand(fromX,toX), Utils.Rand(fromY,toY), Utils.Rand(0.1f,0.3f));
        }
    }
}
