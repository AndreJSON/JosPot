using System;
using System.Collections.Generic;
using System.Text;

namespace JosPot.Entities
{
    public class EntityFactory
    {
        private readonly Random r = new Random();
        public Star CreateStar()
        {
            return new Star((float)(r.NextDouble() + 0.5) * 0.3f);
        }
    }
}
