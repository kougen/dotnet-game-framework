using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Controls;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.UI.WPF.Tiles.Static;
using GameFramework.Visuals.Tiles;
using GameFramework.Visuals.Views;

namespace GameFramework.UI.WPF.Tiles.Interactable
{
    public abstract class AInteractableTileView : ATileView, IMovingObjectView
    {
        private readonly ICollection<IViewLoadedSubscriber> _onLoadedSubscribers = new List<IViewLoadedSubscriber>();
        private readonly ICollection<IViewDisposedSubscriber> _onDisposedSubscribers = new List<IViewDisposedSubscriber>();
        private bool _disposed;
        
        public virtual void UpdatePosition(IPosition2D position)
        {
            Dispatcher.Invoke(() =>
            {
                Canvas.SetLeft(this, position.X * ConfigurationService.Dimension);
                Canvas.SetTop(this, position.Y * ConfigurationService.Dimension);
            });
        }
        
        protected AInteractableTileView(IPosition2D position, IConfigurationService2D configurationService, Color color, bool hasBorder) : base(position, configurationService, color, hasBorder)
        { }
        
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
