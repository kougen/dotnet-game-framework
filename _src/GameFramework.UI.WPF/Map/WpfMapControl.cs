using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using GameFramework.Map.MapObject;
using GameFramework.Visuals;

namespace GameFramework.UI.WPF.Map
{
    public class WpfMapControl : Canvas, IMapView2D, IViewDisposedSubscriber
    {
        private ObservableCollection<IDynamicMapObjectView> _entityViews;
        private ObservableCollection<IMapObject2D> _mapObjects;
        
        public ObservableCollection<IDynamicMapObjectView> EntityViews
        {
            get => _entityViews;
            set
            {
                _entityViews = value;
                UpdateEntities();
            }
        }

        public ObservableCollection<IMapObject2D> MapObjects
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
            EntityViews = _entityViews = new ObservableCollection<IDynamicMapObjectView>();
            MapObjects = _mapObjects = new ObservableCollection<IMapObject2D>();
            EntityViews.CollectionChanged += (sender, args) => UpdateEntities();
            MapObjects.CollectionChanged += (sender, args) => UpdateMapObjects();
        }
        
        public void OnViewDisposed(IDynamicMapObjectView view)
        {
            if (view is Shape shape)
            {
                Children.Remove(shape);
            }
        }
        
        private void UpdateEntities()
        {
            foreach (var entityView in EntityViews)
            {
                if (entityView is Shape shape)
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
                if (mapObject is Shape shape && !Children.Contains(shape))
                {
                    Children.Add(shape);
                } 
            }
        }
    }
}
