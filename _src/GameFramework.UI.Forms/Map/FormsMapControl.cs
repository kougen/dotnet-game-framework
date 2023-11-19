using System.Collections.ObjectModel;
using GameFramework.Impl.Core.Position;
using GameFramework.Map.MapObject;
using GameFramework.UI.Forms.MouseEvents;
using GameFramework.Visuals;

namespace GameFramework.UI.Forms.Map
{
    public class FormsMapControl : Panel, IMapView2D, IViewDisposedSubscriber
    {
        private ObservableCollection<IDynamicMapObjectView> _entityViews;
        private ObservableCollection<IMapObject2D> _mapObjects;
        private readonly ICollection<IMouseHandler> _mouseHandlers = new List<IMouseHandler>();
        
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
        
        protected FormsMapControl()
        {
            MouseMove += (_, _) => OnMouseMove();
            
            EntityViews = _entityViews = new ObservableCollection<IDynamicMapObjectView>();
            MapObjects = _mapObjects = new ObservableCollection<IMapObject2D>();
            EntityViews.CollectionChanged += (_, _) => UpdateEntities();
            MapObjects.CollectionChanged += (_, _) => UpdateMapObjects();
            AutoSize = true;
        }
        
        public virtual void Attach(IMouseHandler mouseHandler)
        {
            _mouseHandlers.Add(mouseHandler);
        }

        public virtual void OnViewDisposed(IDynamicMapObjectView view)
        {
            if (view is Control control)
            {
                Controls.Remove(control);
            }
        }

        protected virtual void OnMouseMove()
        {
            var position = MousePosition;
            foreach (var mouseHandler in _mouseHandlers)
            {
                mouseHandler.OnMouseMove(new ScreenSpacePosition(position.X, position.Y));
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            
            var position = e.Location;
            foreach (var mouseHandler in _mouseHandlers)
            {
                mouseHandler.OnMouseLeftClick(new ScreenSpacePosition(position.X, position.Y));
            }
        }

        private void UpdateEntities()
        {
            foreach (var entityView in EntityViews)
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
