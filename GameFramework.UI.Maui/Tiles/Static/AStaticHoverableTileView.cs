using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Tiles;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace GameFramework.UI.Maui.Tiles.Static
{
    public abstract class AStaticHoverableTileView : AStaticTileView, IHoverable
    {
        protected Color HoverColor { get; }
        public bool IsHovered { get; protected set; }
        
        protected AStaticHoverableTileView(IPosition2D position, IConfigurationService2D configurationService, Color fillColor, Color hoverColor, bool hasBorder = false) : base(position, configurationService, fillColor, hasBorder)
        {
            HoverColor = hoverColor;
        }
        
        public virtual void OnHovered()
        {
            IsHovered = true;
            Background = new SolidColorBrush(HoverColor);
        }
        
        public virtual void OnHoverLost()
        {
            IsHovered = false;
            Background = new SolidColorBrush(FillColor);
        }
    }
}
