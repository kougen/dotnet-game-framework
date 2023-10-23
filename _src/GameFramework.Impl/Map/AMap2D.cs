using System.ComponentModel;
using GameFramework.Core;
using GameFramework.Core.Motion;
using GameFramework.Entities;
using GameFramework.Map;
using GameFramework.Map.MapObject;

namespace GameFramework.Impl.Map
{
    public abstract class AMap2D : IMap2D
    {
        public int SizeX { get; }
        public int SizeY { get; }
        public ICollection<IUnit2D> Entities { get; }
        public IEnumerable<IMapObject2D> MapObjects { get; }

        protected AMap2D(int sizeX, int sizeY, ICollection<IUnit2D> entities, IEnumerable<IMapObject2D> mapObjects)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            Entities = entities;
            MapObjects = mapObjects;
        }

        public virtual void MoveUnit(IUnit2D unit2D, Move2D move)
        {
            var mapObject = SimulateMove(unit2D.Position, move);
            if (mapObject is null || mapObject.IsObstacle)
            {
                return;
            }
            unit2D.Step(mapObject);
        }
        
        public IMapObject2D? SimulateMove(IPosition2D position, Move2D move)
        {
            var objects = MapObjects.ToArray();
            switch (move)
            {
                case Move2D.Forward:
                    if (position.Y - 1 >= 0)
                    {
                        return objects[(position.Y - 1) * SizeX + position.X];
                    }
                    break;
                case Move2D.Backward:
                    if (position.Y + 1 < SizeY)
                    {
                        return objects[(position.Y + 1) * SizeX + position.X];
                    }
                    break;
                case Move2D.Left:
                    if (position.X - 1 >= 0)
                    {
                        return objects[position.Y * SizeX + (position.X - 1)];
                    }
                    break;
                case Move2D.Right:
                    if (position.X + 1 < SizeX)
                    {
                        return objects[position.Y * SizeX + (position.X + 1)];
                    }
                    break;
                default: throw new InvalidEnumArgumentException("Unsupported move!");
            }
            return default;
        }

        public void RegisterUnit(IUnit2D unit2D)
        {
            Entities.Add(unit2D);
        }
    }
}
