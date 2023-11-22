using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Impl.Tiles.Static;
using GameFramework.Objects;
using GameFramework.Objects.Static;
using GameFramework.UI.Forms.Tiles.Static;

namespace GameFramework.UI.Forms.Map
{
    public class FormsStaticObjectConverter : IStaticObject2DConverter
    {
        private readonly IConfigurationService2D _configurationService2D;

        public FormsStaticObjectConverter(IConfigurationService2D configurationService2D)
        {
            _configurationService2D = configurationService2D ?? throw new ArgumentNullException(nameof(configurationService2D));
        }

        public IStaticObject2D FromEnum<T>(T tileType, IPosition2D position) where T : Enum
        {
            if (tileType is not TileType)
            {
                throw new ArgumentException($"tileType must be of type {nameof(TileType)}");
            }

            switch (tileType)
            {
                case TileType.Ground:
                    return new GeneralStaticTile(position, _configurationService2D, new GeneralStaticTileView(position, _configurationService2D)) ;
                default:
                    throw new ArgumentException($"Unknown tile type: {tileType}");
            }
        }

        public IStaticObject2D FromInt(int type, IPosition2D position)
        {
            throw new NotImplementedException();
        }
    }
}
