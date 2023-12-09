using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.UI.Maui.Tiles.Interactable;
using GameFramework.UI.Maui.Tiles.Static;
using GameFramework.Visuals.Factories;
using GameFramework.Visuals.Views;
using Color = System.Drawing.Color;

namespace GameFramework.UI.Maui.Factories;

internal class MauiTileViewFactory : ITileViewFactory2D
{
    private readonly IConfigurationService2D _configurationService2D;
    
    public MauiTileViewFactory(IConfigurationService2D configurationService2D)
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