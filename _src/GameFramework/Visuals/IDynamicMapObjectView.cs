using GameFramework.Core;

namespace GameFramework.Visuals
{
    public interface IDynamicMapObjectView : IDisposable
    {
        void UpdatePosition(IPosition2D position);
        void ViewLoaded();
        void Attach(IViewLoadedSubscriber subscriber);
        void Attach(IViewDisposedSubscriber subscriber);
    }
}
