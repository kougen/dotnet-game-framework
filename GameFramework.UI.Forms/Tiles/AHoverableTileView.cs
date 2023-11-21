using GameFramework.Core.Position;
using GameFramework.Tiles;

namespace GameFramework.UI.Forms.Tiles
{
    public abstract class AHoverableTileView : ATileView, IHoverable
    {
        public bool IsHovered { get; private set; }
        
        protected AHoverableTileView(IPosition2D position, double size, Color fillColor, bool hasBorder = false) : base(position, size, fillColor, hasBorder)
        { }
        
        public virtual void OnHovered()
        {
            IsHovered = true;
        }
        
        public virtual void OnHoverLost()
        {
            IsHovered = false;
        }
    }
}
