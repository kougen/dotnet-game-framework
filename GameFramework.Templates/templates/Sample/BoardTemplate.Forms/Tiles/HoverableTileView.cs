using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Tiles;
using GameFramework.UI.Forms.Tiles.Static;

namespace BoardTemplate.Forms.Tiles
{
    public class HoverableTileView : AStaticTileView, IHoverable
    {
        public bool IsHovered { get; private set; }

        public HoverableTileView(IPosition2D position, IConfigurationService2D configurationService, Color color, bool hasBorder = false) : base(position, configurationService.Dimension, color, hasBorder)
        { }

        public void OnHovered()
        {
            IsHovered = true;
            BackColor = Color.LightGreen;
        }
        
        public void OnHoverLost()
        {
            IsHovered = false;
            BackColor = Color.Green;
        }
    }
}
