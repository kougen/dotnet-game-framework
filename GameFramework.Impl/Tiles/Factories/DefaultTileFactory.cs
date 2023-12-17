using System.Drawing;
using GameFramework.Board;
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
    private readonly IBoardService _boardService;

    public DefaultTileFactory(IBoardService boardService)
    {
        _boardService = boardService ?? throw new ArgumentNullException(nameof(boardService));
    }

    public IInteractableObject2D CreateInteractableTile2D(IPosition2D position, Color fillColor, bool isObstacle = false, bool hasBorder = false)
    {
        return new InteractableTile(position, _boardService, fillColor, isObstacle, hasBorder);
    }

    public IInteractableObject2D CreateHoverableInteractiveObject2D(IPosition2D position, Color fillColor,
        bool isObstacle = false,bool hasBorder = false)
    {
        return new HoverableInteractableTile(position, _boardService, fillColor, isObstacle, hasBorder);
    }

    public IInteractableObject2D CreateClickableInteractiveObject2D(IPosition2D position, Color fillColor,
        bool isObstacle = false,bool hasBorder = false)
    {
        return new ClickableInteractableTile(position, _boardService, fillColor, isObstacle);
    }

    public IInteractableObject2D CreateFocusableInteractiveObject2D(IPosition2D position, Color fillColor,
        bool isObstacle = false,bool hasBorder = false)
    {
        return new FocusableInteractableTile(position, _boardService, fillColor, isObstacle, hasBorder);
    }

    public IStaticObject2D CreateStaticObject2D(IPosition2D position, Color fillColor, bool isObstacle = false, bool hasBorder = false)
    {
        return new StaticTile(position, _boardService, fillColor, isObstacle, hasBorder);
    }

    public IStaticObject2D CreateHoverableStaticObject2D(IPosition2D position, Color fillColor, bool isObstacle = false, bool hasBorder = false)
    {
        return new HoverableStaticTile(position, _boardService, fillColor, isObstacle, hasBorder);
    }

    public IStaticObject2D CreateClickableStaticObject2D(IPosition2D position, Color fillColor, bool isObstacle = false, bool hasBorder = false)
    {
        return new ClickableStaticTile(position, _boardService, fillColor, isObstacle, hasBorder);
    }

    public IStaticObject2D CreateFocusableStaticObject2D(IPosition2D position, Color fillColor, bool isObstacle = false, bool hasBorder = false)
    {
        return new FocusableStaticTile(position, _boardService, fillColor, isObstacle, hasBorder);
    }
}