using System;
using System.Windows.Media;
using BoardTemplate.Game.Game.Tiles;
using BoardTemplate.Game.Tiles;
using BoardTemplate.WPF.Tiles;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Impl.Tiles.Static;
using GameFramework.Objects.Static;
using GameFramework.UI.WPF.Tiles.Static;

namespace BoardTemplate.WPF.Map
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
                TileTypes.GroundTile => new HoverableTile(position, _configurationService2D, new HoverableTileView(position, _configurationService2D, Colors.Green)),
                TileTypes.WallTile => new GeneralStaticTile(position, _configurationService2D, new GeneralStaticTileView(position, _configurationService2D, Colors.Gray), true),
                TileTypes.HoleTile => new GeneralStaticTile(position, _configurationService2D, new GeneralStaticTileView(position, _configurationService2D, Colors.Black)),
                _ => throw new ArgumentException($"Unknown tile type: {tileType}")
            };
        }
    }
}
