using GameFramework.Core;
using GameFramework.Map.MapObject;

namespace GameFramework.Map
{
    public interface IMap2D<out T> : IUnitMap2D where T : IMapSource2D
    {
        T MapSource { get; }
        
        int SizeX { get; }
        int SizeY { get; }
        
        IEnumerable<IMapObject2D> MapObjects { get; }
        IEnumerable<IMapObject2D> MapPortion(IPosition2D topLeft, IPosition2D bottomRight);
        IEnumerable<IMapObject2D> MapPortion(IPosition2D center, int radius);
        IMapObject2D? SelectedObject { get; set; }
        
        void SaveProgress();
    }

    public interface IMap2D : IMap2D<IMapSource2D>
    { }
}
