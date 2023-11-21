using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Tiles;
using GameFramework.Visuals.Views;

namespace GameFramework.Impl.Tiles.Static
{
    public abstract class AHoverableStaticTile : AStaticTile, IHoverable
    {
        public virtual bool IsHovered { get; protected set; }

        protected AHoverableStaticTile(IPosition2D position, IConfigurationService2D configurationService, IStaticObjectView2D view) : base(position, configurationService, view)
        { }
        
        public virtual void OnHovered()
        {
            if (View is not IHoverable hoverableView2D)
            {
                return;
            }
            
            if (hoverableView2D.IsHovered)
            {
                return;
            }
            
            IsHovered = true;
            hoverableView2D.OnHovered();
        }
        
        public virtual void OnHoverLost()
        {
            if (View is not IHoverable hoverableView2D)
            {
                return;
            }
            
            if (!hoverableView2D.IsHovered)
            {
                return;
            }
            
            IsHovered = false;
            hoverableView2D.OnHoverLost();
        }
    }
}
