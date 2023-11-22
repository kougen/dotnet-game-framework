using System;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Impl.Tiles.Static;
using GameFramework.Objects;
using GameFramework.Objects.Static;

namespace GameFramework.ManualTests.Desktop.WPF.GameCanvas
{
    internal class DefaultStaticObjectConverter : IStaticObject2DConverter
    {
        private readonly IConfigurationService2D _configurationService2D;

        public DefaultStaticObjectConverter(IConfigurationService2D configurationService2D)
        {
            _configurationService2D = configurationService2D ?? throw new ArgumentNullException(nameof(configurationService2D));
        }

        public IStaticObject2D FromEnum<T>(T tileType, IPosition2D position) where T : Enum
        {
            if (tileType is not TileType)
            {
                throw new ArgumentException($"tileType must be of type {nameof(TileType)}");
            }
            
            return tileType switch
            {
                TileType.Ground => new GeneralStaticTile(position, _configurationService2D, new TestTileView(position, _configurationService2D)),
                _ => throw new ArgumentException($"Unknown tile type: {tileType}")
            };
        }
    }
}
