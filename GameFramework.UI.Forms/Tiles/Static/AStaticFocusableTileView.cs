using GameFramework.Core.Position;
using GameFramework.Visuals;

namespace GameFramework.UI.Forms.Tiles.Static
{
    public abstract class AStaticFocusableTileView : AStaticClickableTileView, IFocusable
    {
        public bool IsTileFocused { get; private set; }

        protected AStaticFocusableTileView(IPosition2D position, double size, Color fillColor, bool hasBorder = false) : base(position, size, fillColor, hasBorder)
        { }
        
        public virtual void OnFocused()
        {
            IsTileFocused = true;
        }
        
        public virtual void OnFocusLost()
        {
            IsTileFocused = false;
        }
    }
}
