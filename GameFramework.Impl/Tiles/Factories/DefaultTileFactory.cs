using System.Drawing;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Impl.Tiles.Interactable;
using GameFramework.Impl.Tiles.Static;
using GameFramework.Objects.Interactable;
using GameFramework.Objects.Static;
using GameFramework.Tiles.Factories;
using GameFramework.Visuals.Factories;

namespace GameFramework.Impl.Tiles.Factories;

internal class DefaultTileFactory : ITileFactory2D
{
    private readonly ITileViewFactory2D _tileViewFactory2D;
    private readonly IConfigurationService2D _configurationService2D;

    public DefaultTileFactory(ITileViewFactory2D tileViewFactory2D, IConfigurationService2D configurationService2D)
    {
        _tileViewFactory2D = tileViewFactory2D ?? throw new ArgumentNullException(nameof(tileViewFactory2D));
        _configurationService2D =
            configurationService2D ?? throw new ArgumentNullException(nameof(configurationService2D));
    }

    public IInteractableObject2D CreateInteractableTile2D(IPosition2D position, Color fillColor, bool hasBorder = false)
    {
        return new GeneralInteractableTile(
            position,
            _configurationService2D,
            _tileViewFactory2D.CreateInteractableTileView2D(position, fillColor, hasBorder)
        );
    }

    public IStaticObject2D CreateStaticTile2D(IPosition2D position, Color fillColor, bool hasBorder = false)
    {
        return new GeneralStaticTile(
            position,
            _configurationService2D,
            _tileViewFactory2D.CreateTileView2D(position, fillColor, hasBorder)
        );
    }
}