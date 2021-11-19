using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korki.ExtAndUtility
{
    public static class Rand
    {
        private static Random r = null;
        private static Random R { get {
                if (r == null) { r = new Random(); }
                return r;
            }
        }

        /// <summary>
        /// Returns a random integer between min (inclusive) and max (exclusive).
        /// </summary>
        public static int Range(int min, int max) => R.Next(min, max);
        /// <summary>
        /// Returns a random float between min (inclusive) and max (exclusive).
        /// </summary>
        public static float Range(float min, float max) => (float)R.NextDouble() * (max - min) + min;

        public static bool Chance(float chance) => Range(0, 100) < chance;
    }
}
