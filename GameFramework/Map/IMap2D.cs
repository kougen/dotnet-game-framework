using GameFramework.Core.Position;
using GameFramework.Map.Source;
using GameFramework.Objects;
using GameFramework.Objects.Static;
using GameFramework.Visuals.Views;

namespace GameFramework.Map
{
    public interface IMap2D<out TSource, out TView> : IHasIntractable2D 
        where TSource : IMapSource2D
        where TView : IMapView2D
    {
        TView View { get; }
        TSource MapSource { get; }
        
        int SizeX { get; }
        int SizeY { get; }
        
        ICollection<IStaticObject2D> MapObjects { get; }
        IEnumerable<IStaticObject2D> MapPortion(IPosition2D topLeft, IPosition2D bottomRight);
        IEnumerable<IStaticObject2D> MapPortion(IPosition2D center, int radius);
        IObject2D? SelectedObject { get; set; }
        
        void SaveProgress();
    }

    public interface IMap2D : IMap2D<IMapSource2D, IMapView2D>
    { }
}
