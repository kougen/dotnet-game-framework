namespace GameFramework.Visuals
{
    public interface IViewDisposedSubscriber
    {
        void OnViewDisposed(IDynamicMapObjectView view);
    }
}
