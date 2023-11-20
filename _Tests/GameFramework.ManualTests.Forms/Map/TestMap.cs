using GameFramework.Configuration;
using GameFramework.Core.Factories;
using GameFramework.Impl.Map;
using GameFramework.Map;
using GameFramework.Visuals;

namespace GameFramework.ManualTests.Forms.Map
{
    internal class TestMap : AMap2D
    {

        public TestMap(IMapSource2D mapSource, IMapView2D view, IPositionFactory positionFactory, IConfigurationService2D configurationService) : base(mapSource, view, positionFactory, configurationService)
        { }
    }
}
