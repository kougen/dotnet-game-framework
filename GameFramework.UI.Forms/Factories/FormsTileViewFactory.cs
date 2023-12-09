using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.UI.Forms.Tiles.Interactable;
using GameFramework.UI.Forms.Tiles.Static;
using GameFramework.Visuals.Factories;
using GameFramework.Visuals.Views;

namespace GameFramework.UI.Forms.Factories;

internal class FormsTileViewFactory : ITileViewFactory2D
{
    private readonly IConfigurationService2D _configurationService2D;
    
    public FormsTileViewFactory(IConfigurationService2D configurationService2D)
    {
        _configurationService2D =
            configurationService2D ?? throw new ArgumentNullException(nameof(configurationService2D));
    }
    
    public T CreateTileView2D<T>(IPosition2D position2D, Color color, bool hasBorder = false) where T : IStaticObjectView2D
    {
        throw new NotImplementedException();
    }

    public IStaticObjectView2D CreateTileView2D(IPosition2D position2D, Color color, bool hasBorder = false)
    {
        return new GeneralStaticTileView(position2D, _configurationService2D, color, hasBorder);
    }

    public T CreateInteractableTileView2D<T>(IPosition2D position2D, Color color, bool hasBorder = false) where T : IMovingObjectView
    {
        throw new NotImplementedException();
    }

    public IMovingObjectView CreateInteractableTileView2D(IPosition2D position2D, Color color, bool hasBorder = false)
    {
        return new GeneralInteractableTileView(position2D, _configurationService2D, color, hasBorder);
    }
}