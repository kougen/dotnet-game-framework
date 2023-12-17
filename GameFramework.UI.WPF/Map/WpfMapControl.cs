using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using GameFramework.Impl.Core.Position;
using GameFramework.Objects.Interactable;
using GameFramework.Objects.Static;
using GameFramework.Visuals.Handlers;
using GameFramework.Visuals.Tiles;
using GameFramework.Visuals.Views;

namespace GameFramework.UI.WPF.Map
{
    public class WpfMapControl : Canvas, IMapView2D, IViewDisposedSubscriber
    {
        private ObservableCollection<IInteractableObject2D> _interactableObjects;
        private ObservableCollection<IStaticObject2D> _mapObjects;
        private readonly ICollection<IMouseHandler> _mouseHandlers = new List<IMouseHandler>();

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

        public WpfMapControl()
        {
            InteractableObjects = _interactableObjects = new ObservableCollection<IInteractableObject2D>();
            MapObjects = _mapObjects = new ObservableCollection<IStaticObject2D>();
            InteractableObjects.CollectionChanged += (_, _) => UpdateEntities();
            MapObjects.CollectionChanged += (_, _) => UpdateMapObjects();
        }

        public void Attach(IMouseHandler mouseHandler)
        {
            _mouseHandlers.Add(mouseHandler);
        }

        public virtual void Clear()
        {
            Dispatcher.BeginInvoke(() => Children.Clear());
        }

        public void OnViewDisposed(IObjectView2D view)
        {
            if (view is Shape shape)
            {
                Dispatcher.BeginInvoke(() => Children.Remove(shape));
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
            foreach (var interactableObject in InteractableObjects)
            {
                if (interactableObject.View is Shape shape && !Children.Contains(shape))
                {
                    Dispatcher.BeginInvoke(() => Children.Add(shape));
                }

                interactableObject.View.Attach(this);
            }
        }

        private void UpdateMapObjects()
        {
            foreach (var mapObject in MapObjects)
            {
                if (mapObject.View is Shape shape && !Children.Contains(shape))
                {
                    Dispatcher.BeginInvoke(() => Children.Add(shape));
                }
            }
        }
    }
}