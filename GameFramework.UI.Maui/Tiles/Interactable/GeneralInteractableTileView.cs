using GameFramework.Configuration;
using GameFramework.Core.Position;
using Color = System.Drawing.Color;

namespace GameFramework.UI.Maui.Tiles.Interactable;

public class GeneralInteractableTileView : AInteractableTileView
{
    public GeneralInteractableTileView(IPosition2D position, IConfigurationService2D configurationService, Color fillColor, bool hasBorder = false) : base(position, configurationService, fillColor, hasBorder)
    { }
}