using GameFramework.Core;
using GameFramework.Entities;

namespace GameFramework.Map.MapObject
{
    public interface IMapObject2D
    {
        IPosition2D Position { get; }
        bool IsObstacle { get; }
        void SteppedOn(IUnit2D unit2D);
    }
}
