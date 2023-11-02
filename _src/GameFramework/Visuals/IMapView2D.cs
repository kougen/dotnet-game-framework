using System.Collections.ObjectModel;
using GameFramework.Map.MapObject;

namespace GameFramework.Visuals
{
    public interface IMapView2D
    {
        public ObservableCollection<IMapObject2D> MapObjects { get; set; }
        public ObservableCollection<IDynamicMapObjectView> EntityViews { get; set; }
    }
}
