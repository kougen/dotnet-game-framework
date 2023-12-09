using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Tiles;

namespace GameFramework.UI.Maui.Tiles.Static
{
    public abstract class AStaticHoverableTileView : AStaticTileView, IHoverable
    {
        protected System.Drawing.Color HoverColor;
        public bool IsHovered { get; protected set; }
        
        protected AStaticHoverableTileView(IPosition2D position, IConfigurationService2D configurationService, System.Drawing.Color fillColor, System.Drawing.Color hoverColor, bool hasBorder = false) : base(position, configurationService, fillColor, hasBorder)
        {
            HoverColor = hoverColor;
        }
        
        public virtual void OnHovered()
        {
            IsHovered = true;
            Background = new SolidColorBrush(ConvertColor(HoverColor));
        }
        
        public virtual void OnHoverLost()
        {
            IsHovered = false;
            Background = new SolidColorBrush(ConvertColor(HoverColor));
        }
    }
}
