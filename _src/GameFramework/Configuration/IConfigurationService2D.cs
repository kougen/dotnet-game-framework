using GameFramework.Map;
using GameFramework.Visuals;

namespace GameFramework.Configuration
{
    public interface IConfigurationService2D
    {
        int Dimension { get; set; }
        
        T? GetActiveMap<T>() where T : IMap2D;
        void SetActiveMap<T>(T map2D) where T : IMap2D<IMapSource2D, IMapView2D>;
        
        CancellationTokenSource CancellationTokenSource { get; }
    }
}
