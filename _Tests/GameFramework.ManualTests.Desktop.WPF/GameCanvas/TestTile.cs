using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Entities;
using GameFramework.UI.WPF;
using GameFramework.UI.WPF.Tiles;

namespace GameFramework.ManualTests.Desktop.WPF.GameCanvas
{
    public class TestTile : AHoverableTile
    {

        public TestTile(IPosition2D position, IConfigurationService2D configurationService) : base(position, configurationService, Colors.Chocolate, false)
        { }
        public override bool IsObstacle => false;
        
        public override void SteppedOn(IUnit2D unit2D)
        {
            throw new System.NotImplementedException();
        }

        public override void OnHovered()
        {
            base.OnHovered();
            Fill = new SolidColorBrush(Colors.Coral);
        }
        
        public override void OnHoverLost()
        {
            base.OnHoverLost();
            Fill = new SolidColorBrush(Colors.Chocolate);
        }
    }
}
