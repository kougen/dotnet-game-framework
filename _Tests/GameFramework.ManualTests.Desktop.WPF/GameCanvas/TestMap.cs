using GameFramework.Configuration;
using GameFramework.Core.Factories;
using GameFramework.Impl.Map;
using GameFramework.Map;
using GameFramework.Visuals;

namespace GameFramework.ManualTests.Desktop.WPF.GameCanvas
{
    public class TestMap : AMap2D
    {

        public TestMap(IMapSource2D mapSource, IMapView2D view, IPositionFactory positionFactory, IConfigurationService2D configurationService2D) : base(mapSource, view, positionFactory, configurationService2D)
        { }
    }
}
