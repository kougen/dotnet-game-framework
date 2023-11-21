using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Tiles;
using GameFramework.Visuals.Views;

namespace GameFramework.Impl.Tiles.Interactable
{
    public abstract class AHoverableInteractableTile : AInteractableTile, IHoverable
    {
        public virtual bool IsHovered { get; protected set; }

        protected AHoverableInteractableTile(IPosition2D position, IConfigurationService2D configurationService, IMovingObjectView view) : base(position, configurationService, view)
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
