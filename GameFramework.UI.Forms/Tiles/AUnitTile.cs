using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Visuals;

namespace GameFramework.UI.Forms.Tiles
{
    public abstract class AUnitTile : AFocusableTile, IDynamicMapObjectView
    {
        private readonly ICollection<IViewLoadedSubscriber> _onLoadedSubscribers = new List<IViewLoadedSubscriber>();
        private readonly ICollection<IViewDisposedSubscriber> _onDisposedSubscribers = new List<IViewDisposedSubscriber>();
        
        protected AUnitTile(IPosition2D position, IConfigurationService2D configurationService, Color fillColor, bool hasBorder) : base(position, configurationService, fillColor, hasBorder)
        { }
        
        public void UpdatePosition(IPosition2D position)
        {
            BeginInvoke(() =>
            {
                Left = position.X * ConfigurationService.Dimension;
                Top = position.Y * ConfigurationService.Dimension;
            });
        }
        
        public void ViewLoaded()
        {
            foreach (var subscriber in _onLoadedSubscribers)
            {
                subscriber.OnLoaded();
            }
        }
        
        public virtual void Attach(IViewLoadedSubscriber subscriber)
        {
            _onLoadedSubscribers.Add(subscriber);
        }

        public virtual void Attach(IViewDisposedSubscriber subscriber)
        {
            _onDisposedSubscribers.Add(subscriber);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                foreach (var subscriber in _onDisposedSubscribers)
                {
                    subscriber.OnViewDisposed(this);
                }
            }
        }
    }
}
