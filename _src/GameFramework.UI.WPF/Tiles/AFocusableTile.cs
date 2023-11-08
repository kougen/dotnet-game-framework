using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Visuals;

namespace GameFramework.UI.WPF.Tiles
{
    public abstract class AFocusableTile : GeneralTile, IFocusable
    {
        protected AFocusableTile(IPosition2D position, IConfigurationService2D configurationService, Color color) : base(position, configurationService, color)
        { }
        
        public virtual void OnClicked()
        {
            
        }
        
        public virtual void OnFocused()
        {
            
        }
        
        public virtual void OnFocusLost()
        {
            
        }
    }
}
