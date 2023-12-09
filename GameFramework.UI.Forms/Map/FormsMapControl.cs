using System.Collections.ObjectModel;
using GameFramework.Impl.Core.Position;
using GameFramework.Objects.Static;
using GameFramework.UI.Forms.MouseEvents;
using GameFramework.Visuals.Handlers;
using GameFramework.Visuals.Tiles;
using GameFramework.Visuals.Views;

namespace GameFramework.UI.Forms.Map
{
    public class FormsMapControl : Panel, IMapView2D, IViewDisposedSubscriber, IViewLoadedSubscriber
    {
        private ObservableCollection<IDisposableStaticObjectView> _disposableViews;
        private ObservableCollection<IStaticObject2D> _mapObjects;
        private readonly ICollection<IMouseHandler> _mouseHandlers = new List<IMouseHandler>();
        
        public ObservableCollection<IDisposableStaticObjectView> DisposableObjectViews
        {
            get => _disposableViews;
            set
            {
                _disposableViews = value;
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
            
            DisposableObjectViews = _disposableViews = new ObservableCollection<IDisposableStaticObjectView>();
            MapObjects = _mapObjects = new ObservableCollection<IStaticObject2D>();
            DisposableObjectViews.CollectionChanged += (_, _) => UpdateEntities();
            MapObjects.CollectionChanged += (_, _) => UpdateMapObjects();
            AutoSize = true;
        }

        public virtual void Attach(IMouseHandler mouseHandler)
        {
            _mouseHandlers.Add(mouseHandler);
        }

        public virtual void OnViewDisposed(IDisposableStaticObjectView view)
        {
            if (view is Control control)
            {
                Controls.Remove(control);
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
            foreach (var entityView in DisposableObjectViews)
            {
                if (entityView is Control shape && !Controls.Contains(shape))
                {
                    entityView.Attach(this as IViewLoadedSubscriber);
                    entityView.Attach(this as IViewDisposedSubscriber);
                    
                    Controls.Add(shape);
                }
            }
        }
        
        private void UpdateMapObjects()
        {
            foreach (var mapObject in MapObjects)
            {
                if (mapObject.View is Control shape && !Controls.Contains(shape))
                {
                    Controls.Add(shape);
                } 
            }
        }

        public void OnLoaded(IMovingObjectView view)
        {
            if (view is Control shape && !Controls.Contains(shape))
            {
                Controls.Add(shape);
            }
        }
    }
}
