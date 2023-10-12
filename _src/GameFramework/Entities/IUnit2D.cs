using GameFramework.Map.MapObject;

namespace GameFramework.Entities
{
    public interface IUnit2D : IMapObject2D
    {
        void Step(IMapObject2D mapObject);
    }
}
