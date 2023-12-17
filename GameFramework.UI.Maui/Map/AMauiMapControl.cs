using System.Collections.ObjectModel;
using GameFramework.Objects.Interactable;
using GameFramework.Objects.Static;
using GameFramework.Visuals.Handlers;
using GameFramework.Visuals.Tiles;
using GameFramework.Visuals.Views;

namespace GameFramework.UI.Maui.Map
{
    public abstract class AMauiMapControl : AbsoluteLayout, IMapView2D, IViewDisposedSubscriber
    {
        private ObservableCollection<IInteractableObject2D> _interactableObjects;
        private ObservableCollection<IStaticObject2D> _mapObjects;
        protected readonly ICollection<IMouseHandler> MouseHandlers = new List<IMouseHandler>();

        public ObservableCollection<IInteractableObject2D> InteractableObjects
        {
            get => _interactableObjects;
            set
            {
                _interactableObjects = value;
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
            InteractableObjects = _interactableObjects = new ObservableCollection<IInteractableObject2D>();
            MapObjects = _mapObjects = new ObservableCollection<IStaticObject2D>();
            InteractableObjects.CollectionChanged += (_, _) => UpdateEntities();
            MapObjects.CollectionChanged += (_, _) => UpdateMapObjects();
        }

        public void Attach(IMouseHandler mouseHandler)
        {
            MouseHandlers.Add(mouseHandler);
        }

        public virtual void OnViewDisposed(IObjectView2D view)
        {
            if (view is BoxView shape)
            {
                MainThread.BeginInvokeOnMainThread(() => Children.Remove(shape));
            }
        }

        protected virtual void UpdateEntities()
        {
            foreach (var interactableObject in InteractableObjects)
            {
                if (interactableObject.View is BoxView shape && !Children.Contains(shape))
                {
                    MainThread.BeginInvokeOnMainThread(() => Children.Add(shape));
                }

                interactableObject.View.Attach(this);
            }
        }

        protected virtual void UpdateMapObjects()
        {
            foreach (var mapObject in MapObjects)
            {
                if (mapObject.View is BoxView shape && !Children.Contains(shape))
                {
                    MainThread.BeginInvokeOnMainThread(() => Children.Add(shape));
                }
            }
        }

        public new virtual void Clear()
        {
            MainThread.BeginInvokeOnMainThread(() => Children.Clear());
        }
    }
}