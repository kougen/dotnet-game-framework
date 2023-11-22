using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.UI.WPF.Tiles;
using GameFramework.UI.WPF.Tiles.Static;

namespace GameFramework.ManualTests.Desktop.WPF.GameCanvas
{
    public class TestTileView : AHoverableTileView
    {
        public TestTileView(IPosition2D position, IConfigurationService2D configurationService) : base(position, configurationService, Colors.Chocolate, false)
        { }

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
