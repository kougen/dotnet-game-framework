using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Threading;
using GameFramework.Impl.Core.Position;
using GameFramework.Objects.Interactable;
using GameFramework.Objects.Static;
using GameFramework.Visuals.Handlers;
using GameFramework.Visuals.Tiles;
using GameFramework.Visuals.Views;
using Microsoft.VisualBasic;

namespace GameFramework.UI.WPF.Map
{
    public class WpfMapControl : Canvas, IMapView2D, IViewDisposedSubscriber
    {
        private readonly ICollection<IMouseHandler> _mouseHandlers = new List<IMouseHandler>();
        private readonly Dispatcher _dispatcher;

        public ObservableCollection<IInteractableObject2D> InteractableObjects { get; }
        public ObservableCollection<IStaticObject2D> MapObjects { get; }

        public WpfMapControl()
        {
            _dispatcher = Dispatcher.CurrentDispatcher;

            InteractableObjects = InteractableObjects = new ObservableCollection<IInteractableObject2D>();
            MapObjects = MapObjects = new ObservableCollection<IStaticObject2D>();
            InteractableObjects.CollectionChanged += (_, args) => ExecuteOnMainThread(() => UpdateEntities(args));
            MapObjects.CollectionChanged += (_, args) => ExecuteOnMainThread(() => UpdateMapObjects(args));
        }

        public void Attach(IMouseHandler mouseHandler)
        {
            _mouseHandlers.Add(mouseHandler);
        }

        public virtual void Clear()
        {
            ExecuteOnMainThread(Children.Clear);
        }

        public void OnViewDisposed(IObjectView2D view)
        {
            if (view is Shape shape)
            {
                ExecuteOnMainThread(() => Children.Remove(shape));
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

        private void UpdateEntities(NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            foreach (var old in notifyCollectionChangedEventArgs.OldItems ?? new Collection())
            {
                if (old is IInteractableObject2D { View: Shape shape } interactable && Children.Contains(shape))
                {
                    Children.Remove(shape);
                    interactable.Delete();
                }
            }

            foreach (var @new in notifyCollectionChangedEventArgs.NewItems ?? new Collection())
            {
                if (@new is IInteractableObject2D { View: Shape shape } interactableObject2D &&
                    !Children.Contains(shape))
                {
                    Children.Add(shape);
                    interactableObject2D.View.Attach(this);
                }
            }

            foreach (var interactableObject in InteractableObjects)
            {
                if (interactableObject.View is Shape shape && !Children.Contains(shape))
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
                if (old is IStaticObject2D { View: Shape shape } && Children.Contains(shape))
                {
                    Children.Remove(shape);
                }
            }

            foreach (var @new in notifyCollectionChangedEventArgs.NewItems ?? new Collection())
            {
                if (@new is IStaticObject2D { View: Shape shape } mapObject && !Children.Contains(shape))
                {
                    Children.Add(shape);
                    mapObject.View.Attach(this);
                }
            }

            foreach (var mapObject in MapObjects)
            {
                if (mapObject.View is Shape shape && !Children.Contains(shape))
                {
                    ExecuteOnMainThread(() => Children.Add(shape));
                }
            }
        }

        protected void ExecuteOnMainThread(Action action)
        {
            if (_dispatcher.CheckAccess())
            {
                action();
            }
            else
            {
                _dispatcher.Invoke(action);
            }
        }
    }
}