using System.Drawing;
using GameFramework.Configuration;
using GameFramework.Core.Position;

namespace GameFramework.UI.WPF.Tiles.Static
{
    public class GeneralStaticTileView : ATileView
    {
        public GeneralStaticTileView(IPosition2D position, IConfigurationService2D configurationService, Color fillColor, bool hasBorder = false) : base(position, configurationService, fillColor, hasBorder)
        { }
    }
}
