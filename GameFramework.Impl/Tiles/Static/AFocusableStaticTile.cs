using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Visuals;
using GameFramework.Visuals.Views;

namespace GameFramework.Impl.Tiles.Static
{
    public abstract class AFocusableStaticTile : AClickableStaticTile, IFocusable
    {
        public bool IsTileFocused { get; protected set; }

        protected AFocusableStaticTile(IPosition2D position, IConfigurationService2D configurationService, IStaticObjectView2D view) : base(position, configurationService, view)
        { }
        public virtual void OnFocused()
        {
            if(View is not IFocusable focusableView2D)
            {
                return;
            }
            
            if(focusableView2D.IsTileFocused)
            {
                return;
            }
            
            IsTileFocused = true;
            focusableView2D.OnFocused();
        }
        public virtual void OnFocusLost()
        {
            if(View is not IFocusable focusableView2D)
            {
                return;
            }
            
            if(!focusableView2D.IsTileFocused)
            {
                return;
            }
            
            IsTileFocused = false;
            focusableView2D.OnFocusLost();
        }
    }
}
