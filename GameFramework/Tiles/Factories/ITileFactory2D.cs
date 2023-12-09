using System.Drawing;
using GameFramework.Core.Position;
using GameFramework.Objects.Interactable;
using GameFramework.Objects.Static;

namespace GameFramework.Tiles.Factories;

public interface ITileFactory2D
{
    IInteractableObject2D CreateInteractableTile2D(IPosition2D position, Color fillColor, bool hasBorder = false);
    IStaticObject2D CreateStaticTile2D(IPosition2D position, Color fillColor, bool hasBorder = false);
}