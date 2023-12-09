using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.UI.Maui.Tiles.Static;
using GameFramework.Visuals.Tiles;
using GameFramework.Visuals.Views;

namespace GameFramework.UI.Maui.Tiles.Interactable;

public abstract class AInteractableTileView : AStaticTileView, IMovingObjectView
{
    protected ICollection<IViewLoadedSubscriber> OnLoadedSubscribers = new List<IViewLoadedSubscriber>();
    protected ICollection<IViewDisposedSubscriber> OnDisposedSubscribers = new List<IViewDisposedSubscriber>();
    private bool _isDisposed;

    protected AInteractableTileView(IPosition2D position, IConfigurationService2D configurationService, System.Drawing.Color fillColor, bool hasBorder) 
        : base(position, configurationService, fillColor, hasBorder)
    { }
    
    public void Attach(IViewLoadedSubscriber subscriber)
    {
        if (!OnLoadedSubscribers.Contains(subscriber))
        {
            OnLoadedSubscribers.Add(subscriber);
        }
    }

    public void Attach(IViewDisposedSubscriber subscriber)
    {
        if (!OnDisposedSubscribers.Contains(subscriber))
        {
            OnDisposedSubscribers.Add(subscriber);
        }
    }

    public void UpdatePosition(IPosition2D position)
    {
        Dispatcher.Dispatch(() =>
        {
            SetPosition(position);
        });
    }

    public void ViewLoaded()
    {
        foreach (var subscriber in OnLoadedSubscribers)
        {
            subscriber.OnLoaded();
        }
    }
    
    private void Dispose(bool disposing)
    {
        if (_isDisposed || !disposing)
        {
            return;
        }

        foreach (var subscriber in OnDisposedSubscribers)
        {
            subscriber.OnViewDisposed(this);
        }
            
        OnLoadedSubscribers.Clear();
        OnDisposedSubscribers.Clear();
        _isDisposed = true;
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}