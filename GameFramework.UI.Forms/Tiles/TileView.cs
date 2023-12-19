using GameFramework.Core.Position;
using GameFramework.Impl.Core.Position;
using GameFramework.Visuals.Tiles;

namespace GameFramework.UI.Forms.Tiles
{
    public class TileView : UserControl, IObjectView2D
    {
        private readonly ICollection<IViewLoadedSubscriber> _onLoadedSubscribers = new List<IViewLoadedSubscriber>();
        private readonly ICollection<IViewDisposedSubscriber> _onDisposedSubscribers = new List<IViewDisposedSubscriber>();
        
        public IPosition2D Position2D { get; set; }
        public IScreenSpacePosition ScreenSpacePosition { get; }

        public Color FillColor
        {
            get => _fillColor;
            set
            {
                _fillColor = value;
                ExecuteOnMainThread(() => BackColor = FillColor);
            }
        }

        public virtual bool HasBorder { get; set; }

        protected virtual Color BorderColor { get; set; } = Color.Black;
        protected double TileSize;
        private Color _fillColor;

        public TileView(IPosition2D position2D, double size, Color fillColor, bool hasBorder = false)
        {
            Position2D = position2D ?? throw new ArgumentNullException(nameof(position2D));
            TileSize = size;
            Width = (int)size;
            Height = (int)size;
            Top = (int)size * position2D.Y;
            Left = (int)size * position2D.X;
            var location = PointToScreen(Point.Empty);
            var titleHeight = RectangleToScreen(ClientRectangle).Top - Top;
            ScreenSpacePosition = new ScreenSpacePosition(location.X - 8, location.Y - titleHeight);
            HasBorder = hasBorder;
            InitializeColor(fillColor);
        }
        
        private void InitializeColor(Color fillColor)
        {
            if (HasBorder)
            {
                BorderStyle = BorderStyle.FixedSingle;
            }
            
            BackColor = fillColor;
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
        
        protected virtual void ExecuteOnMainThread(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
