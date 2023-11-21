using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Visuals;
using GameFramework.Visuals.Views;

namespace GameFramework.Impl.Tiles.Static
{
    public abstract class AClickableStaticTile : AHoverableStaticTile, IClickable
    {
        public bool IsClickEnabled { get; set; }

        protected AClickableStaticTile(IPosition2D position, IConfigurationService2D configurationService, IStaticObjectView2D view) : base(position, configurationService, view)
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
