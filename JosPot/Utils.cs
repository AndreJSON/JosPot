using System;
using System.Collections.Generic;
using System.Text;

namespace JosPot
{
    public class Utils
    {
        private static readonly Random rand = new Random();

        public static float Rand(float from, float to)
        {
            return ((float)rand.NextDouble() * (to - from)) + from;
        }
    }
}
