using GameFramework.Map;
using GameFramework.Visuals;

namespace GameFramework.Board
{
    public interface IBoardService
    {
        IMap2D? GetActiveMap();
        T? GetActiveMap<T>() where T : IMap2D<IMapSource2D, IMapView2D>;
        T? GetActiveMap<T, TSource, TView>() where T : IMap2D<TSource, TView>
            where TSource : IMapSource2D
            where TView : IMapView2D;

        void SetActiveMap(IMap2D map2D);
        void SetActiveMap<T>(T map2D) where T : IMap2D<IMapSource2D, IMapView2D>;
        void SetActiveMap<T, TSource, TView>(T map2D) where T : IMap2D<TSource, TView>
            where TSource : IMapSource2D
            where TView : IMapView2D;
    }
}
