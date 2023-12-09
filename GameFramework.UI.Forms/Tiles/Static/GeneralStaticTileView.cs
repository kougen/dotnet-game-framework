using GameFramework.Configuration;
using GameFramework.Core.Position;

namespace GameFramework.UI.Forms.Tiles.Static
{
    public class GeneralStaticTileView : AStaticTileView
    {
        public GeneralStaticTileView(IPosition2D position, IConfigurationService2D configurationService, Color color, bool hasBorder = false)
            : base(position, configurationService.Dimension, color, hasBorder)
        { }
    }
}
