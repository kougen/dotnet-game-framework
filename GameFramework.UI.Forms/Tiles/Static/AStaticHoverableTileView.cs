using GameFramework.Core.Position;
using GameFramework.Tiles;
using GameFramework.UI.Forms.Tiles.Static;

namespace GameFramework.UI.Forms.Tiles
{
    public abstract class AStaticHoverableTileView : AStaticTileView, IHoverable
    {
        public bool IsHovered { get; private set; }
        
        protected AStaticHoverableTileView(IPosition2D position, double size, Color fillColor, bool hasBorder = false) : base(position, size, fillColor, hasBorder)
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
