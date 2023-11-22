using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Objects;
using GameFramework.Objects.Interactable;
using GameFramework.Objects.Static;
using GameFramework.Visuals.Views;

namespace GameFramework.Impl.Tiles.Static
{
    public abstract class AStaticTile : IStaticObject2D
    {
        public IStaticObjectView2D View { get; }
        public IPosition2D Position { get; }
        public abstract bool IsObstacle { get; }
        public abstract void SteppedOn(IInteractableObject2D interactableObject2D);

        protected IConfigurationService2D ConfigurationService;
        
        protected AStaticTile(IPosition2D position, IConfigurationService2D configurationService, IStaticObjectView2D view)
        {
            Position = position ?? throw new ArgumentNullException(nameof(position));
            View = view ?? throw new ArgumentNullException(nameof(view));
            ConfigurationService = configurationService ?? throw new ArgumentNullException(nameof(configurationService));
        }
    }
}
