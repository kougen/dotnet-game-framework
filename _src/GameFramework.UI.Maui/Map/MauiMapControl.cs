using GameFramework.Map.MapObject;
using GameFramework.Visuals;
using Microsoft.Maui.Controls.Shapes;
using System.Collections.ObjectModel;

namespace GameFramework.UI.Maui.Map
{
    internal class MauiMapControl : IDrawable, IMapView2D, IViewDisposedSubscriber
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

        protected MauiMapControl()
        {
            EntityViews = _entityViews = new ObservableCollection<IDynamicMapObjectView>();
            MapObjects = _mapObjects = new ObservableCollection<IMapObject2D>();
            EntityViews.CollectionChanged += (sender, args) => UpdateEntities();
            MapObjects.CollectionChanged += (sender, args) => UpdateMapObjects();
        }

        public void Attach(IMouseHandler mouseHandler)
        {
            throw new NotImplementedException();
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            //canvas.DrawRectangle();
            //canvas.Update
        }

        public void OnViewDisposed(IDynamicMapObjectView view)
        {
            throw new NotImplementedException();
        }

        private void UpdateEntities()
        {
            foreach (var entityView in EntityViews)
            {
                //if (entityView is Shape shape && !Children.Contains(shape))
                //{
                //    Children.Add(shape);
                //}
                entityView.Attach(this);
            }
        }

        private void UpdateMapObjects()
        {
            foreach (var mapObject in MapObjects)
            {
                //if (mapObject is Shape shape && !Children.Contains(shape))
                //{
                //    Children.Add(shape);
                //}
            }
        }
    }
}
