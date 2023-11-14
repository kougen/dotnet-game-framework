using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Visuals;

namespace GameFramework.UI.WPF.Tiles
{
    public abstract class AClickableTile : AGeneralTile, IClickable
    {
        protected AClickableTile(IPosition2D position, IConfigurationService2D configurationService, Color color, bool hasBorder) : base(position, configurationService, color, hasBorder)
        { }
        
        public virtual void OnClicked()
        {
            
        }
        
    }
}
