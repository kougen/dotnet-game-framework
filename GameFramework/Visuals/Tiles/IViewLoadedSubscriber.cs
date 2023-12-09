using GameFramework.Visuals.Views;

namespace GameFramework.Visuals.Tiles
{
    public interface IViewLoadedSubscriber
    {
        void OnLoaded(IMovingObjectView view);
    }
}
