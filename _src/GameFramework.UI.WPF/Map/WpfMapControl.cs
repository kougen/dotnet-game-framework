using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using GameFramework.Map.MapObject;
using GameFramework.Visuals;

namespace GameFramework.UI.WPF.Map
{
    public class WpfMapControl : Canvas, IViewDisposedSubscriber
    {
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
                if (mapObject is Shape shape)
                {
                    Children.Add(shape);
                } 
            }
        }
        
        public ObservableCollection<IDynamicMapObjectView> EntityViews
        {
            get => (ObservableCollection<IDynamicMapObjectView>)GetValue(EntityViewsProperty);
            set => SetValue(EntityViewsProperty, value);
        }

        public static readonly DependencyProperty EntityViewsProperty = DependencyProperty.Register(
            nameof(EntityViews), 
            typeof(ObservableCollection<IDynamicMapObjectView>), 
            typeof(WpfMapControl),
            new PropertyMetadata(default(IDynamicMapObjectView), OnEntityViewsChanged));
        
        private static void OnEntityViewsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((WpfMapControl)d).OnEntityViewsChanged((ObservableCollection<IDynamicMapObjectView>)e.NewValue);
        }
        
        private void OnEntityViewsChanged(ObservableCollection<IDynamicMapObjectView> eNewValue)
        {
            EntityViews = eNewValue;
            UpdateEntities();
        }
        
        public ObservableCollection<IMapObject2D> MapObjects
        {
            get => (ObservableCollection<IMapObject2D>)GetValue(MapObjectsProperty);
            set => SetValue(MapObjectsProperty, value);
        }

        public static readonly DependencyProperty MapObjectsProperty = DependencyProperty.Register(
            nameof(MapObjects), 
            typeof(ObservableCollection<IMapObject2D>), 
            typeof(WpfMapControl),
            new PropertyMetadata(default(IDynamicMapObjectView), OnMapObjectsChanged));
        
        private static void OnMapObjectsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((WpfMapControl)d).OnMapObjectsChanged((ObservableCollection<IMapObject2D>)e.NewValue);
        }
        
        private void OnMapObjectsChanged(ObservableCollection<IMapObject2D> eNewValue)
        {
            MapObjects = eNewValue;
            UpdateMapObjects();
        }
    }
}
