using GameFramework.Objects;
using GameFramework.Objects.Interactable;
using GameFramework.Tiles;

namespace GameFramework.Impl.Map.Source.Dummies;

public class DummyInteractable
{
    public int ColorId { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public DummyInteractable(int colorId, int x, int y)
    {
        ColorId = colorId;
        X = x;
        Y = y;
    }

    public DummyInteractable(IObject2D interactable)
    {
        ColorId = ColorConverter.ConvertColorToTileId(interactable.TileColor);
        X = interactable.Position.X;
        Y = interactable.Position.Y;
    }

    public DummyInteractable()
    { }
}