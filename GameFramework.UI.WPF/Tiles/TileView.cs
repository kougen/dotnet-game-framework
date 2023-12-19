using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Impl.Core.Position;
using GameFramework.Visuals.Tiles;
using Color = System.Drawing.Color;
using Point = System.Windows.Point;
using Size = System.Windows.Size;

namespace GameFramework.UI.WPF.Tiles
{
    public class TileView : ACustomShape, IObjectView2D
    {
        public IPosition2D Position2D
        {
            get => _position2D;
            set
            {
                ExecuteOnMainThread(() =>
                {
                    var previousPosition = _position2D;

                    var delta = new Point(
                        value.X * ConfigurationService.Dimension - previousPosition.X * ConfigurationService.Dimension,
                        value.Y * ConfigurationService.Dimension - previousPosition.Y * ConfigurationService.Dimension);
                    _position2D = value;
                    
                    if (delta.X != 0)
                    {
                        Canvas.SetLeft(this, Rect.X + ConfigurationService.Dimension);
                    }

                    if (delta.Y != 0)
                    {
                        Canvas.SetTop(this, Rect.Y + ConfigurationService.Dimension);
                    }

                    if (delta.X != 0 || delta.Y != 0)
                    {
                        Rect = new Rect(
                            new Point(ConfigurationService.Dimension * Position2D.X, ConfigurationService.Dimension * Position2D.Y),
                            new Size(ConfigurationService.Dimension, ConfigurationService.Dimension)
                        );
                        ScreenSpacePosition = new ScreenSpacePosition(Rect.X, Rect.Y);
                    }
                });
            }
        }

        public IScreenSpacePosition ScreenSpacePosition { get; protected set; }

        public Color FillColor
        {
            get => _fillColor;
            set
            {
                _fillColor = value;
                ExecuteOnMainThread(() => Fill = new SolidColorBrush(ConvertColor(FillColor)));
            }
        }

        public bool HasBorder { get; set; }

        protected Color BorderColor = Color.Black;
        private Color _fillColor;
        private IPosition2D _position2D;
        private readonly ICollection<IViewLoadedSubscriber> _onLoadedSubscribers = new List<IViewLoadedSubscriber>();

        private readonly ICollection<IViewDisposedSubscriber> _onDisposedSubscribers =
            new List<IViewDisposedSubscriber>();

        private bool _disposed;

        public TileView(IPosition2D position, IConfigurationService2D configurationService, Color fillColor,
            bool hasBorder) : base(configurationService)
        {
            Rect = new Rect(
                new Point(ConfigurationService.Dimension * position.X, ConfigurationService.Dimension * position.Y),
                new Size(ConfigurationService.Dimension, ConfigurationService.Dimension));
            ScreenSpacePosition = new ScreenSpacePosition(Rect.X, Rect.Y);
            Position2D = _position2D = position ?? throw new ArgumentNullException(nameof(position));
            FillColor = fillColor;
            HasBorder = hasBorder;
            ExecuteOnMainThread(InitializeColor);
        }

        private void InitializeColor()
        {
            Fill = new SolidColorBrush(ConvertColor(FillColor));
            if (HasBorder)
            {
                Stroke = new SolidColorBrush();
            }
        }

        protected static System.Windows.Media.Color ConvertColor(Color color)
        {
            return System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
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

        private void Dispose(bool isDisposing)
        {
            if (_disposed)
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

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}