using GameFramework.Configuration;
using GameFramework.Core.Position;

namespace GameFramework.UI.Maui.Tiles.Static
{
    public class GeneralStaticTileView : AStaticTileView
    {
        public GeneralStaticTileView(IPosition2D position, IConfigurationService2D configurationService, System.Drawing.Color fillColor, bool hasBorder = false) : base(position, configurationService, fillColor, hasBorder)
        { }
    }
}
