using GameFramework.Board;
using GameFramework.Configuration;
using GameFramework.Map;
using GameFramework.Map.Source;
using GameFramework.Visuals.Factories;
using GameFramework.Visuals.Views;

namespace GameFramework.Impl
{
    internal class BoardService : IBoardService
    {
        private object? _activeMap;

        public ITileViewFactory2D TileViewFactory2D { get; }
        public IMapViewFactory2D MapViewFactory2D { get; }
        public IConfigurationService2D ConfigurationService2D { get; }
        
        public BoardService(ITileViewFactory2D tileViewFactory2D, IMapViewFactory2D mapViewFactory2D, IConfigurationService2D configurationService2D)
        {
            TileViewFactory2D = tileViewFactory2D ?? throw new ArgumentNullException(nameof(tileViewFactory2D));
            MapViewFactory2D = mapViewFactory2D ?? throw new ArgumentNullException(nameof(mapViewFactory2D));
            ConfigurationService2D = configurationService2D ?? throw new ArgumentNullException(nameof(configurationService2D));
        }

        public IMap2D? GetActiveMap()
        {
            return _activeMap as IMap2D;
        }
        
        public T? GetActiveMap<T>() where T : IMap2D<IMapSource2D, IMapView2D>
        {
            if (_activeMap is T map)
            {
                return map;
            }
            
            return default;
        }
        
        public T? GetActiveMap<T, TSource, TView>() where T : IMap2D<TSource, TView>
            where TSource : IMapSource2D
            where TView : IMapView2D
        {
            if (_activeMap is T map)
            {
                return map;
            }
            
            return default;
        }
        
        public void SetActiveMap(IMap2D map2D)
        {
            _activeMap = map2D ?? throw new ArgumentNullException(nameof(map2D));
        }
        
        public void SetActiveMap<T>(T map2D) where T : IMap2D<IMapSource2D, IMapView2D>
        {
            _activeMap = map2D ?? throw new ArgumentNullException(nameof(map2D));
        }
        
        public void SetActiveMap<T, TSource, TView>(T map2D) where T : IMap2D<TSource, TView>
            where TSource : IMapSource2D
            where TView : IMapView2D
        {
            _activeMap = map2D ?? throw new ArgumentNullException(nameof(map2D));   
        }
    }
}
