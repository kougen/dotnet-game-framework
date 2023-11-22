using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core.Position;

namespace GameFramework.UI.WPF.Tiles.Interactable
{
    public class GeneralInteractableTileView : AInteractableTileView
    {
        public GeneralInteractableTileView(IPosition2D position, IConfigurationService2D configurationService, Color color, bool hasBorder = false) : base(position, configurationService, color, hasBorder)
        { }
    }
}
