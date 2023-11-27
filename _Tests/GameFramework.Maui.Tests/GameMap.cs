using GameFramework.Configuration;
using GameFramework.Core.Factories;
using GameFramework.Impl.Map;
using GameFramework.Map.Source;
using GameFramework.Visuals.Views;

namespace GameFramework.Maui.Tests
{
    public class GameMap : AMap2D<IMapSource2D, IMapView2D>
    {
        public GameMap(IMapSource2D mapSource, IMapView2D view, IPositionFactory positionFactory, IConfigurationService2D configurationService2D) : base(mapSource, view, positionFactory, configurationService2D)
        { }
    }
}
