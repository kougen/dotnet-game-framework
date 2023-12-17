using System.Drawing;
using GameFramework.Core.Position;
using GameFramework.Visuals.Tiles;

namespace GameFramework.Visuals.Factories;

public interface ITileViewFactory2D
{
    IObjectView2D CreateTileView2D(IPosition2D position2D, Color color, bool hasBorder = false);
}