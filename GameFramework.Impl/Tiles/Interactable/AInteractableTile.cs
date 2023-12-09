using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Objects;
using GameFramework.Objects.Interactable;
using GameFramework.Visuals.Tiles;
using GameFramework.Visuals.Views;

namespace GameFramework.Impl.Tiles.Interactable
{
    public abstract class AInteractableTile : IInteractableObject2D, IViewLoadedSubscriber
    {
        public Guid Id { get; }
        public IMovingObjectView View { get; }
        public IPosition2D Position { get; protected set; }
        public bool IsObstacle { get; protected set; }
        public abstract void SteppedOn(IInteractableObject2D interactableObject2D);

        protected IConfigurationService2D ConfigurationService;
        
        protected AInteractableTile(IPosition2D position, IConfigurationService2D configurationService, IMovingObjectView view, bool isObstacle = false)
        {
            Id = Guid.NewGuid();
            Position = position ?? throw new ArgumentNullException(nameof(position));
            View = view ?? throw new ArgumentNullException(nameof(view));
            ConfigurationService = configurationService ?? throw new ArgumentNullException(nameof(configurationService));
            IsObstacle = isObstacle;
            View.Attach(this);
        }
        
        public abstract void Step(IObject2D staticObject);
        public abstract void Delete();

        public virtual void Dispose()
        {
            View.Dispose();
        }

        public virtual void OnLoaded()
        {
            View.UpdatePosition(Position);
        }
    }
}
