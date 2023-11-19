using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Visuals;

namespace GameFramework.UI.Forms.Tiles
{
    public abstract class AHoverableTile : ATile, IHoverable
    {
        public bool IsHovered { get; private set; } = false;
        
        protected AHoverableTile(IPosition2D position, IConfigurationService2D configurationService, Color fillColor, bool hasBorder = false) : base(position, configurationService, fillColor, hasBorder)
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
