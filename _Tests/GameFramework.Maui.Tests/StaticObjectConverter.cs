using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Impl.Tiles.Static;
using GameFramework.Objects;
using GameFramework.Objects.Static;
using GameFramework.UI.Maui.Tiles.Static;

namespace GameFramework.Maui.Tests
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
            if (tileType is not TileType)
            {
                throw new ArgumentException($"tileType must be of type {nameof(TileType)}");
            }
            
            return tileType switch
            {
                TileType.Ground => new (position, _configurationService2D, new GenericHoverableStaticTileView(position, _configurationService2D, Colors.Green, Colors.LightGreen)),
                TileType.Wall => new GeneralStaticTile(position, _configurationService2D, new GenericStaticTileView(position, _configurationService2D, Colors.Gray), true),
                TileType.Hole => new GeneralStaticTile(position, _configurationService2D, new GenericStaticTileView(position, _configurationService2D, Colors.Black)),
                _ => throw new ArgumentException($"Unknown tile type: {tileType}")
            };
        }
    }
}
