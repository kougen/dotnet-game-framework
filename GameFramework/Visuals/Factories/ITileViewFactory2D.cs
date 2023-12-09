using System.Drawing;
using GameFramework.Core.Position;
using GameFramework.Visuals.Views;

namespace GameFramework.Visuals.Factories;

public interface ITileViewFactory2D
{
    T CreateTileView2D<T>(IPosition2D position2D, Color color, bool hasBorder = false) where T : IStaticObjectView2D;
    IStaticObjectView2D CreateTileView2D(IPosition2D position2D, Color color, bool hasBorder = false);

    T CreateInteractableTileView2D<T>(IPosition2D position2D, Color color, bool hasBorder = false)
        where T : IMovingObjectView;

    IMovingObjectView CreateInteractableTileView2D(IPosition2D position2D, Color color, bool hasBorder = false);
}