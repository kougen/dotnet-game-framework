using GameFramework.Configuration;
using GameFramework.Core.Position;

namespace GameFramework.UI.Maui.Tiles.Static
{
    public class GeneralHoverableStaticTileView : AStaticHoverableTileView
    {
        public GeneralHoverableStaticTileView(IPosition2D position, IConfigurationService2D configurationService, System.Drawing.Color fillColor, System.Drawing.Color hoverColor, bool hasBorder = false) : base(position, configurationService, fillColor, hoverColor, hasBorder)
        { }
    }
}
