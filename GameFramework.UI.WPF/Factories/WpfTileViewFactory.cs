using System;
using System.Drawing;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.UI.WPF.Tiles;
using GameFramework.Visuals.Factories;
using GameFramework.Visuals.Tiles;

namespace GameFramework.UI.WPF.Factories;

internal class WpfTileViewFactory : ITileViewFactory2D
{
    private readonly IConfigurationService2D _configurationService2D;

    public WpfTileViewFactory(IConfigurationService2D configurationService2D)
    {
        _configurationService2D =
            configurationService2D ?? throw new ArgumentNullException(nameof(configurationService2D));
    }

    public IObjectView2D CreateTileView2D(IPosition2D position2D, Color color, bool hasBorder = false)
    {
        return new TileView(position2D, _configurationService2D, color, hasBorder);
    }
    
}