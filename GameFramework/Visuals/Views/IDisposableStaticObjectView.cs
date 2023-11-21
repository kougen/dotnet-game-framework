using GameFramework.Visuals.Tiles;

namespace GameFramework.Visuals.Views
{
    public interface IDisposableStaticObjectView : IStaticObjectView2D, IDisposable
    {
        void Attach(IViewLoadedSubscriber subscriber);
        void Attach(IViewDisposedSubscriber subscriber);
    }
}
