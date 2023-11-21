using GameFramework.Core.Position;

namespace GameFramework.Visuals.Views
{
    public interface IMovingObjectView : IDisposableStaticObjectView
    {
        void UpdatePosition(IPosition2D position);
        void ViewLoaded();
    }
}
