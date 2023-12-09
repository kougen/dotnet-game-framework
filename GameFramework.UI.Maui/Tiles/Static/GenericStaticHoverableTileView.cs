using GameFramework.Configuration;
using GameFramework.Core.Position;
using Microsoft.Maui.Graphics;

namespace GameFramework.UI.Maui.Tiles.Static
{
    public class GenericHoverableStaticTileView : AStaticHoverableTileView
    {
        public GenericHoverableStaticTileView(IPosition2D position, IConfigurationService2D configurationService, Color fillColor, Color hoverColor, bool hasBorder = false) : base(position, configurationService, fillColor, hoverColor, hasBorder)
        { }
    }
}
