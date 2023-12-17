using System.Drawing;
using GameFramework.Core.Position;
using GameFramework.Objects.Interactable;
using GameFramework.Objects.Static;

namespace GameFramework.Tiles.Factories;

public interface ITileFactory2D
{
    IInteractableObject2D CreateInteractableTile2D(IPosition2D position, Color fillColor, bool isObstacle = false,
        bool hasBorder = false);

    IInteractableObject2D CreateHoverableInteractiveObject2D(IPosition2D position, Color fillColor,
        bool isObstacle = false, bool hasBorder = false);

    IInteractableObject2D CreateClickableInteractiveObject2D(IPosition2D position, Color fillColor,
        bool isObstacle = false, bool hasBorder = false);

    IInteractableObject2D CreateFocusableInteractiveObject2D(IPosition2D position, Color fillColor,
        bool isObstacle = false, bool hasBorder = false);

    IStaticObject2D CreateStaticObject2D(IPosition2D position, Color fillColor, bool isObstacle = false,
        bool hasBorder = false);

    IStaticObject2D CreateHoverableStaticObject2D(IPosition2D position, Color fillColor,
        bool isObstacle = false, bool hasBorder = false);

    IStaticObject2D CreateClickableStaticObject2D(IPosition2D position, Color fillColor,
        bool isObstacle = false, bool hasBorder = false);

    IStaticObject2D CreateFocusableStaticObject2D(IPosition2D position, Color fillColor,
        bool isObstacle = false, bool hasBorder = false);
}