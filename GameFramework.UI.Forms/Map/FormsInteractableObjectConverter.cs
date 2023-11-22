using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Impl.Tiles.Interactable;
using GameFramework.Impl.Tiles.Static;
using GameFramework.Objects;
using GameFramework.Objects.Interactable;
using GameFramework.Objects.Static;
using GameFramework.UI.Forms.Tiles.Interactable;
using GameFramework.UI.Forms.Tiles.Static;

namespace GameFramework.UI.Forms.Map
{
    public class FormsInteractableObjectConverter : IInteractableObject2DConverter
    {
        private readonly IConfigurationService2D _configurationService2D;

        public FormsInteractableObjectConverter(IConfigurationService2D configurationService2D)
        {
            _configurationService2D = configurationService2D ?? throw new ArgumentNullException(nameof(configurationService2D));
        }

        public IInteractableObject2D FromEnum<T>(T tileType, IPosition2D position) where T : Enum
        {
            if (tileType is not TileType)
            {
                throw new ArgumentException($"tileType must be of type {nameof(TileType)}");
            }

            switch (tileType)
            {
                case TileType.Ground:
                    return new GeneralInteractableTile(position, _configurationService2D, new GeneralInteractableTileView(position, _configurationService2D.Dimension, Color.Green)) ;
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
