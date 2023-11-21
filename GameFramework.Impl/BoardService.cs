using GameFramework.Board;
using GameFramework.Map;
using GameFramework.Map.Source;
using GameFramework.Visuals.Views;

namespace GameFramework.Impl
{
    internal class BoardService : IBoardService
    {
        private object? _activeMap;

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
