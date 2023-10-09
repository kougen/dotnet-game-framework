using GameFramework.Core.Factories;

namespace GameFramework.Impl.Core
{
    internal class Position3D : Position2D, IPosition3D
    {
        public int Z { get; }

        internal Position3D(int x, int y, int z) : base(x, y)
        {
            Z = z;
        }
    }
}
