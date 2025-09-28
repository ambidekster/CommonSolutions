using Unity.Mathematics;

namespace CommonSolutions.Runtime.Extensions
{
    public static class MathExtensions
    {
        public static readonly int2 Zero = int2.zero;
        
        public static readonly int2 Up = new int2(0, 1);
        public static readonly int2 Down = new int2(0, -1);
        public static readonly int2 Left = new int2(-1, 0);
        public static readonly int2 Right = new int2(1, 0);

        public static int2 ToUp(this int2 source)
        {
            return source + Up;
        }

        public static int2 ToDown(this int2 source)
        {
            return source + Down;
        }

        public static int2 ToLeft(this int2 source)
        {
            return source + Left;
        }

        public static int2 ToRight(this int2 source)
        {
            return source + Right;
        }
    }
}