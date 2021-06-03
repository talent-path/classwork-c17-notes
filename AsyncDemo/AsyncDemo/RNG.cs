using System;
namespace AsyncDemo
{
    public static class RNG
    {
        static Random _rng = new Random();


        public static int NextInt( int incMin, int incMax)
        {
            return _rng.Next(incMin, incMax + 1);
        }
    }
}
