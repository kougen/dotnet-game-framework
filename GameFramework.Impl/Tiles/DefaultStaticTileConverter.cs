using System.Drawing;
using GameFramework.Core.Position;
using GameFramework.Objects;
using GameFramework.Objects.Static;
using GameFramework.Tiles.Factories;

namespace GameFramework.Impl.Tiles;

internal class DefaultStaticTileConverter : IStaticObject2DConverter
{
    private readonly ITileFactory2D _tileFactory2D;

    public DefaultStaticTileConverter(ITileFactory2D tileFactory2D)
    {
        _tileFactory2D = tileFactory2D ?? throw new ArgumentNullException(nameof(tileFactory2D));
    }

    public IStaticObject2D FromEnum<T>(T tileType, IPosition2D position) where T : Enum
    {
        if (tileType is not TileType)
        {
            throw new ArgumentException($"tileType must be of type {nameof(TileType)}");
        }
            
        return tileType switch
        {
            TileType.Ground => _tileFactory2D.CreateStaticTile2D(position, Color.Green),
            TileType.Hole => _tileFactory2D.CreateStaticTile2D(position, Color.Black),
            TileType.Wall => _tileFactory2D.CreateStaticTile2D(position, Color.Gray),
            _ => throw new ArgumentException($"Unknown tile type: {tileType}")
        };
    }
}