using GameFramework.Visuals.Views;

namespace GameFramework.Visuals.Tiles
{
    public interface IViewDisposedSubscriber
    {
        void OnViewDisposed(IObjectView2D view);
    }
}
