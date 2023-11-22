using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.UI.WPF.Tiles.Static;

namespace BoardTemplate.WPF.Tiles
{
    public class HoverableTileView : AHoverableTileView
    {
        public HoverableTileView(IPosition2D position, IConfigurationService2D configurationService, Color color, bool hasBorder = false) : base(position, configurationService, color, hasBorder)
        { }

        public override void OnHovered()
        {
            base.OnHovered();
            Fill = new SolidColorBrush(Colors.LightGreen);
        }
        
        public override void OnHoverLost()
        {
            base.OnHoverLost();
            Fill = new SolidColorBrush(Colors.Green);
        }
    }
}
