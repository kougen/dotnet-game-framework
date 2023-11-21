using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Visuals;
using GameFramework.Visuals.Views;

namespace GameFramework.Impl.Tiles.Interactable
{
    public abstract class AClickableInteractableTile : AHoverableInteractableTile, IClickable
    {
        public bool IsClickEnabled { get; set; }

        protected AClickableInteractableTile(IPosition2D position, IConfigurationService2D configurationService, IMovingObjectView view) : base(position, configurationService, view)
        { }
        
        public virtual void OnClicked()
        {
            if (View is not IClickable clickable)
            {
                return;
            }
            
            if (!clickable.IsClickEnabled)
            {
                return;
            }
            
            clickable.OnClicked();
        }
    }
}
