using System.Collections.ObjectModel;
using System.Collections.Specialized;
using GameFramework.Objects.Interactable;
using GameFramework.Objects.Static;
using GameFramework.Visuals.Handlers;
using GameFramework.Visuals.Tiles;
using GameFramework.Visuals.Views;
using Microsoft.VisualBasic;

namespace GameFramework.UI.Maui.Map
{
    public abstract class AMauiMapControl : AbsoluteLayout, IMapView2D, IViewDisposedSubscriber
    {
        protected readonly ICollection<IMouseHandler> MouseHandlers = new List<IMouseHandler>();

        public ObservableCollection<IInteractableObject2D> InteractableObjects { get; }
        public ObservableCollection<IStaticObject2D> MapObjects { get; }

        protected AMauiMapControl()
        {
            InteractableObjects = InteractableObjects = new ObservableCollection<IInteractableObject2D>();
            MapObjects = MapObjects = new ObservableCollection<IStaticObject2D>();
            InteractableObjects.CollectionChanged += (_, args) => ExecuteOnMainThread(() => UpdateEntities(args));
            MapObjects.CollectionChanged += (_, args) => ExecuteOnMainThread(() => UpdateMapObjects(args));
        }

        public void Attach(IMouseHandler mouseHandler)
        {
            MouseHandlers.Add(mouseHandler);
        }

        public virtual void OnViewDisposed(IObjectView2D view)
        {
            if (view is BoxView shape)
            {
                ExecuteOnMainThread(() => Children.Remove(shape));
            }
        }

        private void UpdateEntities(NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            foreach (var old in notifyCollectionChangedEventArgs.OldItems ?? new Collection())
            {
                if (old is IInteractableObject2D { View: BoxView shape } interactable && Children.Contains(shape))
                {
                    Children.Remove(shape);
                    interactable.Delete();
                }
            }

            foreach (var @new in notifyCollectionChangedEventArgs.NewItems ?? new Collection())
            {
                if (@new is IInteractableObject2D { View: BoxView shape } interactableObject2D &&
                    !Children.Contains(shape))
                {
                    Children.Add(shape);
                    interactableObject2D.View.Attach(this);
                }
            }

            foreach (var interactableObject in InteractableObjects)
            {
                if (interactableObject.View is BoxView shape && !Children.Contains(shape))
                {
                    Children.Add(shape);
                }

                interactableObject.View.Attach(this);
            }
        }

        private void UpdateMapObjects(NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            foreach (var old in notifyCollectionChangedEventArgs.OldItems ?? new Collection())
            {
                if (old is IStaticObject2D { View: BoxView shape } && Children.Contains(shape))
                {
                    Children.Remove(shape);
                }
            }

            foreach (var @new in notifyCollectionChangedEventArgs.NewItems ?? new Collection())
            {
                if (@new is IStaticObject2D { View: BoxView shape } mapObject && !Children.Contains(shape))
                {
                    Children.Add(shape);
                    mapObject.View.Attach(this);
                }
            }

            foreach (var mapObject in MapObjects)
            {
                if (mapObject.View is BoxView shape && !Children.Contains(shape))
                {
                    ExecuteOnMainThread(() => Children.Add(shape));
                }
            }
        }

        public new virtual void Clear()
        {
            ExecuteOnMainThread(Children.Clear);
        }

        protected void ExecuteOnMainThread(Action action)
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
    }
}