using BoardTemplate.Forms.Tiles;
using BoardTemplate.Game.Game.Tiles;
using BoardTemplate.Game.Tiles;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Impl.Tiles.Static;
using GameFramework.Objects.Static;

namespace BoardTemplate.Forms.Map
{
    internal class StaticObjectConverter : IStaticObject2DConverter
    {
        private readonly IConfigurationService2D _configurationService2D;

        public StaticObjectConverter(IConfigurationService2D configurationService2D)
        {
            _configurationService2D = configurationService2D ?? throw new ArgumentNullException(nameof(configurationService2D));
        }

        public IStaticObject2D FromEnum<T>(T tileType, IPosition2D position) where T : Enum
        {
            if (tileType is not TileTypes)
            {
                throw new ArgumentException($"tileType must be of type {nameof(TileTypes)}");
            }
            
            return tileType switch
            {
                TileTypes.GroundTile => new HoverableTile(position, _configurationService2D, new HoverableTileView(position, _configurationService2D, Color.Green)),
                TileTypes.WallTile => new GeneralStaticTile(position, _configurationService2D, new GeneralStaticTileView(position, _configurationService2D.Dimension, Color.Gray), true),
                TileTypes.HoleTile => new GeneralStaticTile(position, _configurationService2D, new GeneralStaticTileView(position, _configurationService2D.Dimension, Color.Black)),
                _ => throw new ArgumentException($"Unknown tile type: {tileType}")
            };
        }
    }
}
