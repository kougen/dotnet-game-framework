using GameFramework.Visuals.Views;

namespace GameFramework.Objects
{
    public interface IStaticObject2D : IObject2D
    {
        IStaticObjectView2D View { get; }
    }
}
