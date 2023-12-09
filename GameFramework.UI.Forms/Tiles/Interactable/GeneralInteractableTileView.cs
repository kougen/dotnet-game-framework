using GameFramework.Configuration;
using GameFramework.Core.Position;

namespace GameFramework.UI.Forms.Tiles.Interactable
{
    public class GeneralInteractableTileView : AInteractableTileView
    {
        public GeneralInteractableTileView(IPosition2D position, IConfigurationService2D configurationService2D,
            Color fillColor, bool hasBorder = false) 
            : base(position, configurationService2D.Dimension, fillColor, hasBorder)
        { }
    }
}