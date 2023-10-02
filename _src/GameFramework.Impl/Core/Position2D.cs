using GameFramework.Core;

namespace GameFramework.Impl.Core
{
    public class Position2D : IPosition2D
    {
        public int X { get; }
        public int Y { get; }

        internal Position2D(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
