using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using GameFramework.Impl.Core.Position;
using GameFramework.Objects;
using GameFramework.Visuals.Handlers;
using GameFramework.Visuals.Tiles;
using GameFramework.Visuals.Views;

namespace GameFramework.UI.WPF.Map
{
    public class WpfMapControl : Canvas, IMapView2D, IViewDisposedSubscriber
    {
        private ObservableCollection<IDisposableStaticObjectView> _disposableObjectViews;
        private ObservableCollection<IStaticObject2D> _mapObjects;
        private readonly ICollection<IMouseHandler> _mouseHandlers = new List<IMouseHandler>();
        
        public ObservableCollection<IDisposableStaticObjectView> DisposableObjectViews
        {
            get => _disposableObjectViews;
            set
            {
                _disposableObjectViews = value;
                UpdateEntities();
            }
        }

        public ObservableCollection<IStaticObject2D> MapObjects
        {
            get => _mapObjects;
            set
            {
                _mapObjects = value;
                UpdateMapObjects();
            }
        }
        
        protected WpfMapControl()
        {
            DisposableObjectViews = _disposableObjectViews = new ObservableCollection<IDisposableStaticObjectView>();
            MapObjects = _mapObjects = new ObservableCollection<IStaticObject2D>();
            DisposableObjectViews.CollectionChanged += (_, _) => UpdateEntities();
            MapObjects.CollectionChanged += (_, _) => UpdateMapObjects();
        }
        
        public void Attach(IMouseHandler mouseHandler)
        {
            _mouseHandlers.Add(mouseHandler);
        }

        public void OnViewDisposed(IDisposableStaticObjectView view)
        {
            if (view is Shape shape)
            {
                Children.Remove(shape);
            }
        }
        
        protected override void OnPreviewMouseMove(MouseEventArgs e)
        {
            base.OnPreviewMouseMove(e);
            var position = e.GetPosition(this);
            foreach (var mouseHandler in _mouseHandlers)
            {
                mouseHandler.OnMouseMove(new ScreenSpacePosition(position.X, position.Y));
            }
        }
        
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            var position = e.GetPosition(this);
            foreach (var mouseHandler in _mouseHandlers)
            {
                mouseHandler.OnMouseLeftClick(new ScreenSpacePosition(position.X, position.Y));
            }
        }
        
        private void UpdateEntities()
        {
            foreach (var entityView in DisposableObjectViews)
            {
                if (entityView is Shape shape && !Children.Contains(shape))
                {
                    Children.Add(shape);
                }
                entityView.Attach(this);
            }
        }
        
        private void UpdateMapObjects()
        {
            foreach (var mapObject in MapObjects)
            {
                if (mapObject.View is Shape shape && !Children.Contains(shape))
                {
                    Children.Add(shape);
                } 
            }
        }
    }
}
