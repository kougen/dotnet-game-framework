using System;
using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Map.MapObject;
using GameFramework.UI.WPF.Tiles;

namespace GameFramework.UI.WPF.Map
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
            if (tileType is not TileType)
            {
                throw new ArgumentException($"tileType must be of type {nameof(TileType)}");
            }
            
            return tileType switch
            {
                TileType.Ground => new GroundTile(position, _configurationService2D, _gameManager),
                TileType.Wall => new WallTile(position, _configurationService2D),
                TileType.Hole => new HoleTile(position, _configurationService2D, _gameManager),
                _ => throw new ArgumentException($"Unknown tile type: {tileType}")
            };
        }

        public IMapObject2D FromInt(int type, IPosition2D position)
        {
            throw new NotImplementedException();
        }
    }
}
