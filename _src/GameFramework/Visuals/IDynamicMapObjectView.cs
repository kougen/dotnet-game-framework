using GameFramework.Core;
using GameFramework.Core.Position;

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
