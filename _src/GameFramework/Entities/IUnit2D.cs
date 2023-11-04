using GameFramework.Map.MapObject;
using GameFramework.Visuals;

namespace GameFramework.Entities
{
    public interface IUnit2D : IMapObject2D, IDisposable
    {
        
        Guid Id { get; }
        IDynamicMapObjectView View { get; }

        void Step(IMapObject2D mapObject);
        void Kill();
    }
}
