using GameFramework.Core.Position;
using GameFramework.Visuals;

namespace GameFramework.UI.Forms.Tiles
{
    public abstract class AStaticClickableTileView : AStaticHoverableTileView, IClickable
    {
        public bool IsClickEnabled { get; set; }

        protected AStaticClickableTileView(IPosition2D position, double size, Color fillColor, bool hasBorder = false) : base(position, size, fillColor, hasBorder)
        { }
        
        public virtual void OnClicked()
        { }
    }
}
