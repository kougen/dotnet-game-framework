using System;
using System.Diagnostics;
using GameFramework.Configuration;
using GameFramework.Core.Factories;
using GameFramework.Impl.Map;

namespace GameFramework.ManualTests.Desktop.WPF.GameCanvas
{
    public class TestMap : AMap2D<TestMapSource, TestMapView>
    {

        public TestMap(TestMapSource mapSource, TestMapView view, IPositionFactory positionFactory, IConfigurationService2D configurationService2D) : base(mapSource, view, positionFactory, configurationService2D)
        { }

        private void DoDebug()
        {
            Debug.WriteLine($"Dimension: {ConfigurationService2D.Dimension}");
            Debug.WriteLine("MapObjects:");
            foreach (var mapObject2D in MapObjects)
            {
                Debug.WriteLine(PositionFactory.CreatePosition(mapObject2D.Position.X, mapObject2D.Position.Y));
            }
        }
    }
}
