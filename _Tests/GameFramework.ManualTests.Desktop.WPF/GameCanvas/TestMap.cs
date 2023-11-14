using GameFramework.Configuration;
using GameFramework.Core.Factories;
using GameFramework.Impl.Map;

namespace GameFramework.ManualTests.Desktop.WPF.GameCanvas
{
    public class TestMap : AMap2D<TestMapSource, TestMapView>
    {

        public TestMap(TestMapSource mapSource, TestMapView view, IPositionFactory positionFactory, IConfigurationService2D configurationService2D) : base(mapSource, view, positionFactory, configurationService2D)
        { }
    }
}
