using System;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Map.MapObject;

namespace GameFramework.ManualTests.Desktop.WPF.GameCanvas
{
    internal class DefaultMapObjectConverter : IMapObject2DConverter
    {
        private readonly IConfigurationService2D _configurationService2D;

        public DefaultMapObjectConverter(IConfigurationService2D configurationService2D)
        {
            _configurationService2D = configurationService2D ?? throw new ArgumentNullException(nameof(configurationService2D));
        }

        public IMapObject2D FromEnum<T>(T tileType, IPosition2D position) where T : Enum
        {
            if (tileType is not TileType)
            {
                throw new ArgumentException($"tileType must be of type {nameof(TileType)}");
            }
            
            return tileType switch
            {
                TileType.Ground => new TestTile(position, _configurationService2D),
                _ => throw new ArgumentException($"Unknown tile type: {tileType}")
            };
        }

        public IMapObject2D FromInt(int type, IPosition2D position)
        {
            throw new NotImplementedException();
        }
    }
}
