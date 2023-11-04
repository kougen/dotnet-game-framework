using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Visuals;

namespace GameFramework.UI.WPF.Tiles
{
    public class GeneralClickableTile : GeneralTile, IClickable
    {
        public GeneralClickableTile(IPosition2D position, IConfigurationService2D configurationService, Color color) : base(position, configurationService, color)
        { }
        public virtual void OnClicked()
        {
            
        }
    }
}
