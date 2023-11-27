using GameFramework.Configuration;
using GameFramework.Core.Position;
using Microsoft.Maui.Graphics;

namespace GameFramework.UI.Maui.Tiles.Static
{
    public class GenericStaticTileView : AStaticTileView
    {
        public GenericStaticTileView(IPosition2D position, IConfigurationService2D configurationService, Color fillColor, bool hasBorder = false) : base(position, configurationService, fillColor, hasBorder)
        { }
    }
}
