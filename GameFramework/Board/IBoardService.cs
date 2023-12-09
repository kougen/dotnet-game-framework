using GameFramework.Map;
using GameFramework.Map.Source;
using GameFramework.Visuals.Factories;
using GameFramework.Visuals.Views;

namespace GameFramework.Board
{
    public interface IBoardService
    {
        ITileViewFactory2D TileViewFactory2D { get; }
        IMapViewFactory2D MapViewFactory2D { get; }
        
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
