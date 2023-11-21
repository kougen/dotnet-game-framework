using System.Collections.ObjectModel;
using GameFramework.Impl.Core.Position;
using GameFramework.Objects;
using GameFramework.UI.Forms.MouseEvents;
using GameFramework.Visuals;
using GameFramework.Visuals.Handlers;
using GameFramework.Visuals.Tiles;
using GameFramework.Visuals.Views;

namespace GameFramework.UI.Forms.Map
{
    public class FormsMapControl : Panel, IMapView2D, IViewDisposedSubscriber
    {
        private ObservableCollection<IDisposableStaticObjectView> _entityViews;
        private ObservableCollection<IStaticObject2D> _mapObjects;
        private readonly ICollection<IMouseHandler> _mouseHandlers = new List<IMouseHandler>();
        
        public ObservableCollection<IDisposableStaticObjectView> DisposableObjectViews
        {
            get => _entityViews;
            set
            {
                _entityViews = value;
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
        
        protected FormsMapControl()
        {
            var gmh = new GlobalMouseEventHandler.GlobalMouseHandler();
            gmh.TheMouseMoved += OnMouseMove;
            gmh.TheLeftButtonDown += OnMouseDown;
            System.Windows.Forms.Application.AddMessageFilter(gmh);
            
            DisposableObjectViews = _entityViews = new ObservableCollection<IDisposableStaticObjectView>();
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
                    Controls.Add(shape);
                }
                entityView.Attach(this);
            }
        }
        
        private void UpdateMapObjects()
        {
            foreach (var mapObject in MapObjects)
            {
                if (mapObject is Control shape && !Controls.Contains(shape))
                {
                    Controls.Add(shape);
                } 
            }
        }
    }
}
