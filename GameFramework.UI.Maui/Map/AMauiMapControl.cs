using System.Collections.ObjectModel;
using GameFramework.Objects.Static;
using GameFramework.Visuals.Handlers;
using GameFramework.Visuals.Tiles;
using GameFramework.Visuals.Views;

namespace GameFramework.UI.Maui.Map
{
    public abstract class AMauiMapControl : AbsoluteLayout, IMapView2D, IViewDisposedSubscriber
    {
        private ObservableCollection<IDisposableStaticObjectView> _disposableObjectViews;
        private ObservableCollection<IStaticObject2D> _mapObjects;
        protected readonly ICollection<IMouseHandler> MouseHandlers = new List<IMouseHandler>();
        
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

        protected AMauiMapControl()
        {
            DisposableObjectViews = _disposableObjectViews = new ObservableCollection<IDisposableStaticObjectView>();
            MapObjects = _mapObjects = new ObservableCollection<IStaticObject2D>();
            DisposableObjectViews.CollectionChanged += (_, _) => UpdateEntities();
            MapObjects.CollectionChanged += (_, _) => UpdateMapObjects();
        }
        
        public void Attach(IMouseHandler mouseHandler)
        {
            MouseHandlers.Add(mouseHandler);
        }

        public virtual void OnViewDisposed(IDisposableStaticObjectView view)
        {
            if (view is BoxView shape)
            {
                Children.Remove(shape);
            }
        }
        
        private void UpdateEntities()
        {
            foreach (var entityView in DisposableObjectViews)
            {
                if (entityView is BoxView shape && !Children.Contains(shape))
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
                if (mapObject.View is BoxView shape && !Children.Contains(shape))
                {
                    Children.Add(shape);
                } 
            }
        }
    }
}
