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
            var objects = MapObjects.ToArray();
            switch (move)
            {
                case Move2D.Forward:
                    if (unit2D.Position.Y - 1 >= 0)
                    {
                        var target = objects[(unit2D.Position.Y - 1) * SizeX + unit2D.Position.X];
                        if (!target.IsObstacle)
                        {
                            target.SteppedOn(unit2D);
                        }
                    }
                    break;
                case Move2D.Backward:
                    if (unit2D.Position.Y + 1 < SizeY)
                    {
                        var target = objects[(unit2D.Position.Y - 1) * SizeX + unit2D.Position.X];
                        if (!target.IsObstacle)
                        {
                            target.SteppedOn(unit2D);
                        }
                    }
                    break;
                case Move2D.Left:
                    if (unit2D.Position.X - 1 >= 0)
                    {
                        var target = objects[unit2D.Position.Y * SizeX + (unit2D.Position.X - 1)];
                        if (!target.IsObstacle)
                        {
                            target.SteppedOn(unit2D);
                        }
                    }
                    break;
                case Move2D.Right:
                    if (unit2D.Position.X + 1 < SizeX)
                    {
                        var target = objects[unit2D.Position.Y * SizeX + (unit2D.Position.X + 1)];
                        if (!target.IsObstacle)
                        {
                            target.SteppedOn(unit2D);
                        }
                    }
                    break;
            }
        }
        
        public void RegisterUnit(IUnit2D unit2D)
        {
            Entities.Add(unit2D);
        }
    }
}
