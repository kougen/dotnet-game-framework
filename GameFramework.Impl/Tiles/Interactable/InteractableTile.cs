using System.Drawing;
using GameFramework.Board;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Objects;
using GameFramework.Objects.Interactable;
using GameFramework.Visuals.Factories;
using GameFramework.Visuals.Tiles;

namespace GameFramework.Impl.Tiles.Interactable
{
    public class InteractableTile : IInteractableObject2D, IViewLoadedSubscriber
    {
        public Guid Id { get; }
        public IObjectView2D View { get; protected init; }
        public IPosition2D Position { get; protected set; }
        public bool IsObstacle { get; protected set; }

        protected IConfigurationService2D ConfigurationService;
        protected readonly ITileViewFactory2D TileViewFactory2D;

        public InteractableTile(IPosition2D position, IBoardService boardService, Color fillColor, bool isObstacle = false, bool hasBorder = false)
        {
            Id = Guid.NewGuid();
            Position = position ?? throw new ArgumentNullException(nameof(position));
            ConfigurationService = boardService.ConfigurationService2D;
            TileViewFactory2D = boardService.TileViewFactory2D;
            IsObstacle = isObstacle;
            View = TileViewFactory2D.CreateTileView2D(position, fillColor, hasBorder);
        }
        
        public virtual void SteppedOn(IInteractableObject2D interactableObject2D)
        {
            
        }
        
        public virtual void Step(IObject2D staticObject)
        {
            Position = staticObject.Position;
            View.Position2D = staticObject.Position;
        }
        
        public virtual void Delete()
        {
            
        }

        public virtual void Dispose()
        {
            View.Dispose();
        }

        public virtual void OnLoaded(IObjectView2D _)
        {
            View.Position2D = Position;
        }
    }
}
