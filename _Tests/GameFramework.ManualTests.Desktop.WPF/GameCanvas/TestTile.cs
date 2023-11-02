using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Entities;
using GameFramework.UI.WPF;

namespace GameFramework.ManualTests.Desktop.WPF.GameCanvas
{
    public class TestTile : ATile
    {

        public TestTile(IPosition2D position, IConfigurationService2D configurationService) : base(position, configurationService)
        {
            Fill = new SolidColorBrush(Colors.Chocolate);
        }
        public override bool IsObstacle => false;
        
        public override void SteppedOn(IUnit2D unit2D)
        {
            throw new System.NotImplementedException();
        }
    }
}
