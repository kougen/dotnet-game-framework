﻿using GameFramework.Core;
using GameFramework.Core.Factories;
using GameFramework.Core.Position;

namespace GameFramework.Impl.Core.Position.Factories
{
    internal class PositionFactory : IPositionFactory
    {

        public IPosition2D CreatePosition(int x, int y)
        {
            return new Position2D(x, y);
        }
        public IPosition3D CreatePosition(int x, int y, int z)
        {
            return new Position3D(x, y, z);
        }
    }
}
