using GameFramework.Core.Position;
using GameFramework.UI.Forms.Tiles.Static;
using GameFramework.Visuals.Tiles;
using GameFramework.Visuals.Views;

namespace GameFramework.UI.Forms.Tiles.Interactable
{
    public abstract class AInteractableTileView : AStaticTileView, IMovingObjectView
    {
        private readonly ICollection<IViewLoadedSubscriber> _onLoadedSubscribers = new List<IViewLoadedSubscriber>();
        private readonly ICollection<IViewDisposedSubscriber> _onDisposedSubscribers = new List<IViewDisposedSubscriber>();

        protected AInteractableTileView(IPosition2D position, double size, Color fillColor, bool hasBorder) : base(
            position, size, fillColor, hasBorder)
        { }
        
        public void UpdatePosition(IPosition2D position)
        {
            BeginInvoke(() =>
            {
                BringToFront();
                Left = (int)Math.Round(position.X * Size);
                Top = (int)Math.Round(position.Y * Size);
            });
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ViewLoaded();
        }

        public void ViewLoaded()
        {
            foreach (var subscriber in _onLoadedSubscribers)
            {
                subscriber.OnLoaded(this);
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
