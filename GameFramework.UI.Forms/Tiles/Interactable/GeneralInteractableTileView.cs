using GameFramework.Core.Position;

namespace GameFramework.UI.Forms.Tiles.Interactable
{
    public class GeneralInteractableTileView : AInteractableTileView
    {
        public GeneralInteractableTileView(IPosition2D position, double size, Color fillColor, bool hasBorder = false) : base(position, size, fillColor, hasBorder)
        { }
    }
}
