using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Impl.Core.Position;
using GameFramework.Visuals.Tiles;

namespace GameFramework.UI.Maui.Tiles
{
    public class TileView : BoxView, IObjectView2D
    {
        private readonly ICollection<IViewLoadedSubscriber> _onLoadedSubscribers = new List<IViewLoadedSubscriber>();
        private readonly ICollection<IViewDisposedSubscriber> _onDisposedSubscribers = new List<IViewDisposedSubscriber>();
        private bool _isDisposed;
        
        private System.Drawing.Color _fillColor;
        private IPosition2D _position2D;

        public IPosition2D Position2D
        {
            get => _position2D;
            set
            {
                _position2D = value;
                SetPosition(Position2D);
            }
        }

        public IScreenSpacePosition ScreenSpacePosition { get; protected set; }

        public System.Drawing.Color FillColor
        {
            get => _fillColor;
            set
            {
                _fillColor = value;
                ExecuteOnMainThread(() => Background = new SolidColorBrush(ConvertColor(FillColor)));
            }
        }

        public bool HasBorder { get; set; }

        private readonly IConfigurationService2D _configurationService;

        public TileView(IPosition2D position, IConfigurationService2D configurationService,
            System.Drawing.Color fillColor, bool hasBorder)
        {
            Position2D = position ?? throw new ArgumentNullException(nameof(position));
            _configurationService =
                configurationService ?? throw new ArgumentNullException(nameof(configurationService));
            FillColor = fillColor;
            WidthRequest = _configurationService.Dimension;
            HeightRequest = _configurationService.Dimension;
            Background = new SolidColorBrush(ConvertColor(FillColor));
            SetPosition(position);
            HasBorder = hasBorder;

            if (ScreenSpacePosition == null)
            {
                throw new ArgumentNullException(nameof(ScreenSpacePosition));
            }
        }

        private void SetPosition(IPosition2D position)
        {
            ExecuteOnMainThread(() =>
            {
                var rect = new Rect(_configurationService.Dimension * position.X,
                    _configurationService.Dimension * position.Y, _configurationService.Dimension,
                    _configurationService.Dimension);
                AbsoluteLayout.SetLayoutBounds(this, rect);
                ScreenSpacePosition = new ScreenSpacePosition(rect.Top, rect.Left);
            });
        }

        private static Color ConvertColor(System.Drawing.Color color)
        {
            return Color.FromRgba(color.R, color.G, color.B, color.A);
        }

        private static void ExecuteOnMainThread(Action action)
        {
            if (MainThread.IsMainThread)
            {
                action();
            }
            else
            {
                MainThread.BeginInvokeOnMainThread(action);
            }
        }

        public virtual void ViewLoaded()
        {
            foreach (var subscriber in _onLoadedSubscribers)
            {
                subscriber.OnLoaded(this);
            }
        }

        public virtual void Attach(IViewLoadedSubscriber subscriber)
        {
            if (!_onLoadedSubscribers.Contains(subscriber))
            {
                _onLoadedSubscribers.Add(subscriber);
            }
        }

        public virtual void Attach(IViewDisposedSubscriber subscriber)
        {
            if (!_onDisposedSubscribers.Contains(subscriber))
            {
                _onDisposedSubscribers.Add(subscriber);
            }
        }
        
        private void Dispose(bool isDisposing)
        {
            if (_isDisposed)
            {
                return;
            }
            
            if (isDisposing)
            {
                foreach (var subscriber in _onDisposedSubscribers)
                {
                    subscriber.OnViewDisposed(this);
                }
            }

            _onLoadedSubscribers.Clear();
            _onDisposedSubscribers.Clear();
            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}