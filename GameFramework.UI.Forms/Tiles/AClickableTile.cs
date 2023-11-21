using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Visuals;

namespace GameFramework.UI.Forms.Tiles
{
    public abstract class AClickableTile : AHoverableTile, IClickable
    {
        public bool IsClickEnabled { get; set; }

        protected AClickableTile(IPosition2D position, IConfigurationService2D configurationService, Color fillColor, bool hasBorder = false) : base(position, configurationService, fillColor, hasBorder)
        { }
        
        public virtual void OnClicked()
        { }
    }
}
