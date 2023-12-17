using GameFramework.Configuration;
using GameFramework.Core.Position.Factories;
using GameFramework.Impl.Map;
using GameFramework.Map.Source;
using GameFramework.Visuals.Views;

namespace GameFramework.Maui.Tests.TestUnitVisuals;

public class GameMap : AMap2D
{
    public GameMap(IMapSource2D mapSource, IMapView2D view, IPositionFactory positionFactory, IConfigurationService2D configurationService) : base(mapSource, view, positionFactory, configurationService)
    {
    }
}