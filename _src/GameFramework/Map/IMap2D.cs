using GameFramework.Core;
using GameFramework.Core.Position;
using GameFramework.Map.MapObject;
using GameFramework.Visuals;

namespace GameFramework.Map
{
    public interface IMap2D<out TSource, out TView> : IHasUnits2D 
        where TSource : IMapSource2D
        where TView : IMapView2D
    {
        TView View { get; }
        TSource MapSource { get; }
        
        int SizeX { get; }
        int SizeY { get; }
        
        ICollection<IMapObject2D> MapObjects { get; }
        IEnumerable<IMapObject2D> MapPortion(IPosition2D topLeft, IPosition2D bottomRight);
        IEnumerable<IMapObject2D> MapPortion(IPosition2D center, int radius);
        IMapObject2D? SelectedObject { get; set; }
        
        void SaveProgress();
    }

    public interface IMap2D : IMap2D<IMapSource2D, IMapView2D>
    { }
}
