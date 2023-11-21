using System;
using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Core.Position;
using GameFramework.Map.MapObject;
using GameFramework.UI.WPF.Tiles;
using GameFramework.WPF.Game.Tiles;

namespace GameFramework.WPF.Game.Map
{
    internal class DefaultMapObjectConverter : IMapObject2DConverter
    {
        private readonly IConfigurationService2D _configurationService2D;
        private readonly IGameManager _gameManager;

        public DefaultMapObjectConverter(IConfigurationService2D configurationService2D, IGameManager gameManager)
        {
            _configurationService2D = configurationService2D ?? throw new ArgumentNullException(nameof(configurationService2D));
            _gameManager = gameManager ?? throw new ArgumentNullException(nameof(gameManager));
        }

        public IMapObject2D FromEnum<T>(T tileType, IPosition2D position) where T : Enum
        {
            if (tileType is not TileTypes)
            {
                throw new ArgumentException($"tileType must be of type {nameof(TileTypes)}");
            }
            
            return tileType switch
            {
                TileTypes.GroundTile => new GroundTile(position, _configurationService2D, _gameManager),
                TileTypes.WallTile => new WallTile(position, _configurationService2D),
                TileTypes.HoleTile => new HoleTile(position, _configurationService2D, _gameManager),
                _ => throw new ArgumentException($"Unknown tile type: {tileType}")
            };
        }

        public IMapObject2D FromInt(int type, IPosition2D position)
        {
            throw new NotImplementedException();
        }
    }
}
