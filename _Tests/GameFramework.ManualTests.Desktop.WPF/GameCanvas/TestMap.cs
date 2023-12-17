using System.Diagnostics;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Core.Position.Factories;
using GameFramework.Impl.Map;
using GameFramework.ManualTests.Desktop.WPF.GameCanvas.TestUnitVisuals;

namespace GameFramework.ManualTests.Desktop.WPF.GameCanvas
{
    public class TestMap : AMap2D<TestMapSource, TestMapView>
    {

        public TestMap(TestMapSource mapSource, TestMapView view, IPositionFactory positionFactory, IConfigurationService2D configurationService2D) : base(mapSource, view, positionFactory, configurationService2D)
        { }

        public override void OnMouseLeftClick(IScreenSpacePosition screenSpacePosition)
        {
            base.OnMouseLeftClick(screenSpacePosition);
            
            if(HoveredPosition is null)
            {
                return;
            }
            
            var unit = new TestInteractableObject(HoveredPosition);
            Interactables.Add(unit);
            unit.DoStep();
        }

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
