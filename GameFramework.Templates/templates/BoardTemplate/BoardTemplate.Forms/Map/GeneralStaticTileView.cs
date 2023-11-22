using GameFramework.Core.Position;
using GameFramework.UI.Forms.Tiles.Static;

namespace BoardTemplate.Forms.Map
{
    public class GeneralStaticTileView : AStaticTileView
    {
        public GeneralStaticTileView(IPosition2D position2D, double size, Color fillColor, bool hasBorder = false) : base(position2D, size, fillColor, hasBorder)
        { }
    }
}
