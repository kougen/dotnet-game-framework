using GameFramework.Core.Position;
using GameFramework.Entities;

namespace GameFramework.Map.MapObject
{
    public interface IMapObject2D
    {
        IPosition2D Position { get; }
        IScreenSpacePosition ScreenSpacePosition { get; }
        bool IsObstacle { get; }
        void SteppedOn(IUnit2D unit2D);
    }
}
