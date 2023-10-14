using GameFramework.Core;
using GameFramework.Core.Motion;
using GameFramework.Entities;
using GameFramework.Map.MapObject;

namespace GameFramework.Map
{
    public interface IMap2D
    {
        int SizeX { get; }
        int SizeY { get; }
        IEnumerable<IMapObject2D> MapObjects { get; }
        ICollection<IUnit2D> Entities { get; }
        void MoveUnit(IUnit2D unit2D, Move2D move);
        IMapObject2D? SimulateMove(IPosition2D position, Move2D move);
        void RegisterUnit(IUnit2D unit2D);
    }
}
