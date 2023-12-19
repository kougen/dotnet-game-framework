using System.Collections.ObjectModel;
using GameFramework.Impl.Core.Position;
using GameFramework.Objects.Interactable;
using GameFramework.Objects.Static;
using GameFramework.UI.Forms.MouseEvents;
using GameFramework.Visuals.Handlers;
using GameFramework.Visuals.Tiles;
using GameFramework.Visuals.Views;

namespace GameFramework.UI.Forms.Map
{
    public class FormsMapControl : Panel, IMapView2D, IViewDisposedSubscriber, IViewLoadedSubscriber
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
        
        public FormsMapControl()
        {
            var gmh = new GlobalMouseEventHandler.GlobalMouseHandler();
            gmh.TheMouseMoved += OnMouseMove;
            gmh.TheLeftButtonDown += OnMouseDown;
            System.Windows.Forms.Application.AddMessageFilter(gmh);
            
            InteractableObjects = _interactableObjects = new ObservableCollection<IInteractableObject2D>();
            MapObjects = _mapObjects = new ObservableCollection<IStaticObject2D>();
            InteractableObjects.CollectionChanged += (_, _) => UpdateEntities();
            MapObjects.CollectionChanged += (_, _) => UpdateMapObjects();
            AutoSize = true;
        }

        public virtual void Attach(IMouseHandler mouseHandler)
        {
            _mouseHandlers.Add(mouseHandler);
        }

        public virtual void Clear()
        {
            ExecuteOnMainThread(Controls.Clear);
        }

        public virtual void OnViewDisposed(IObjectView2D view)
        {
            if (view is Control control)
            {
                ExecuteOnMainThread(() => Controls.Remove(control));
            }
        }

        protected virtual void OnMouseMove()
        {
            var position = PointToClient(Cursor.Position);
            
            foreach (var mouseHandler in _mouseHandlers)
            {
                mouseHandler.OnMouseMove(new ScreenSpacePosition(position.X, position.Y));
            }
        }

        private void OnMouseDown()
        {
            var position = PointToClient(Cursor.Position);
            
            foreach (var mouseHandler in _mouseHandlers)
            {
                mouseHandler.OnMouseLeftClick(new ScreenSpacePosition(position.X, position.Y));
            }
        }

        private void UpdateEntities()
        {
            foreach (var interactableObject in InteractableObjects)
            {
                if (interactableObject.View is Control shape && !Controls.Contains(shape))
                {
                    interactableObject.View.Attach(this as IViewLoadedSubscriber);
                    interactableObject.View.Attach(this as IViewDisposedSubscriber);

                    ExecuteOnMainThread(() => Controls.Add(shape));
                }
            }
        }
        
        private void UpdateMapObjects()
        {
            foreach (var mapObject in MapObjects)
            {
                if (mapObject.View is Control shape && !Controls.Contains(shape))
                {
                    ExecuteOnMainThread(() => Controls.Add(shape));
                } 
            }
        }

        public virtual void OnLoaded(IObjectView2D view)
        {
            if (view is Control shape && !Controls.Contains(shape))
            {
                ExecuteOnMainThread(() => Controls.Add(shape));
            }
        }
        
        private void ExecuteOnMainThread(Action action)
        {
            if (!InvokeRequired)
            {
                action();
            }
            else
            {
                Invoke(action);
            }
        }
    }
}
