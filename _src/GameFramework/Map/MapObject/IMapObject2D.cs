using GameFramework.Core;
using GameFramework.Entities;
using GameFramework.Visuals;

namespace GameFramework.Map.MapObject
{
    public interface IMapObject2D : IHoverable
    {
        IPosition2D Position { get; }
        IScreenSpacePosition ScreenSpacePosition { get; }
        bool IsObstacle { get; }
        void SteppedOn(IUnit2D unit2D);
    }
}
