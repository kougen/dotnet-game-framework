
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using GameFramework.Map.MapObject;
using GameFramework.Visuals;
using Microsoft.Maui.Controls.Shapes;

namespace GameFramework.UI.Maui.Map
{
    internal class MauiMapControl : GraphicsView, IMapView2D, IViewDisposedSubscriber
    {
        private ObservableCollection<IDynamicMapObjectView> _entityViews;
        private ObservableCollection<IMapObject2D> _mapObjects;

        public ObservableCollection<IMapObject2D> MapObjects { get; set; }
        public ObservableCollection<IDynamicMapObjectView> EntityViews { get; set; }

        private readonly List<IMouseHandler> _mouseHandlers;

        public MauiMapControl()
        {
            _mouseHandlers = new List<IMouseHandler>();
            EntityViews = _entityViews = new ObservableCollection<IDynamicMapObjectView>();
            MapObjects = _mapObjects = new ObservableCollection<IMapObject2D>();
            EntityViews.CollectionChanged += (sender, args) => UpdateEntities(args);
            MapObjects.CollectionChanged += (sender, args) => UpdateMapObjects(args);
        }


        public void OnViewDisposed(IDynamicMapObjectView view)
        {
            throw new NotImplementedException();
        }

        public void Attach(IMouseHandler mouseHandler)
        {
            if (!_mouseHandlers.Contains(mouseHandler))
            {
                _mouseHandlers.Add(mouseHandler);
            }
        }

        private void UpdateEntities(NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            foreach (var item in notifyCollectionChangedEventArgs.OldItems ?? new List<IDynamicMapObjectView>())
            {
                if (notifyCollectionChangedEventArgs.Action == NotifyCollectionChangedAction.Remove &&
                    item is IDynamicMapObjectView entity)
                {
                    
                }
            }

            foreach (var entityView in EntityViews)
            {
                //if (entityView is Shape shape && !Children.Contains(shape))
                //{
                //    Children.Add(shape);
                //}
                entityView.Attach(this);
            }
        }

        private void UpdateMapObjects(NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            foreach (var mapObject in MapObjects)
            {
                //if (mapObject is Shape shape && !Children.Contains(shape))
                //{
                //    Children.Add(shape);
                //}
            }
        }
    }
}
