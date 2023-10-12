using GameFramework.Core.Motion;
using GameFramework.Entities;
using GameFramework.Map.MapObject;

namespace GameFramework.Map
{
    public interface IMap2D
    {
        int SizeX { get; }
        int SizeY { get; }
        ICollection<IUnit2D> Entities { get; }
        IEnumerable<IMapObject2D> MapObjects { get; }
        void MoveUnit(IUnit2D unit2D, Move2D move);
        void RegisterUnit(IUnit2D unit2D);
    }
}
