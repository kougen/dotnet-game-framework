using GameFramework.Visuals.Views;

namespace GameFramework.Visuals.Tiles
{
    public interface IViewDisposedSubscriber
    {
        void OnViewDisposed(IDisposableStaticObjectView view);
    }
}
