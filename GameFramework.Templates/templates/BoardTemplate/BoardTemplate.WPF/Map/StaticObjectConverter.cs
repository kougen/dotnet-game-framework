using System;
using BoardTemplate.Game.Game.Tiles;
using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Core.Position;
using GameFramework.Impl.Tiles.Static;
using GameFramework.Objects.Static;

namespace BoardTemplate.WPF.Map
{
    internal class StaticObjectConverter : IStaticObject2DConverter
    {
        private readonly IConfigurationService2D _configurationService2D;
        private readonly IGameManager _gameManager;

        public StaticObjectConverter(IConfigurationService2D configurationService2D, IGameManager gameManager)
        {
            _configurationService2D = configurationService2D ?? throw new ArgumentNullException(nameof(configurationService2D));
            _gameManager = gameManager ?? throw new ArgumentNullException(nameof(gameManager));
        }

        public IStaticObject2D FromEnum<T>(T tileType, IPosition2D position) where T : Enum
        {
            if (tileType is not TileTypes)
            {
                throw new ArgumentException($"tileType must be of type {nameof(TileTypes)}");
            }
            
            return tileType switch
            {
                TileTypes.GroundTile => new GeneralStaticTile(position, _configurationService2D, new General),
                TileTypes.WallTile => new WallTile(position, _configurationService2D),
                TileTypes.HoleTile => new HoleTile(position, _configurationService2D, _gameManager),
                _ => throw new ArgumentException($"Unknown tile type: {tileType}")
            };
        }
    }
}
