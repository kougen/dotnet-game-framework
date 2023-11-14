using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Visuals;

namespace GameFramework.UI.WPF.Tiles
{
    public abstract class AHoverableTile : ATile, IHoverable
    {
        public bool IsHovered { get; protected set; }

        protected AHoverableTile(IPosition2D position, IConfigurationService2D configurationService, Color color, bool hasBorder) : base(position, configurationService, color, hasBorder)
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
