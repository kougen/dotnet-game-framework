using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Visuals;

namespace GameFramework.UI.Forms.Tiles
{
    public abstract class AFocusableTile : AClickableTile, IFocusable
    {
        public bool IsTileFocused { get; private set; }

        protected AFocusableTile(IPosition2D position, IConfigurationService2D configurationService, Color fillColor, bool hasBorder = false) : base(position, configurationService, fillColor, hasBorder)
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
