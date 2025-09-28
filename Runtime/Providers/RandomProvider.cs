using System;

namespace CommonSolutions.Runtime.Providers
{
    public class RandomProvider : IRandomProvider
    {
        public Random Random { get; }

        public RandomProvider(int seed = 0)
        {
            Random = new Random(seed);
        }
    }
}