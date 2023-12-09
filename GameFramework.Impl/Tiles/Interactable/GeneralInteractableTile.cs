using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Objects;
using GameFramework.Objects.Interactable;
using GameFramework.Visuals.Views;

namespace GameFramework.Impl.Tiles.Interactable
{
    public class GeneralInteractableTile : AInteractableTile
    {
        public GeneralInteractableTile(IPosition2D position, IConfigurationService2D configurationService, IMovingObjectView view, bool isObstacle = false) : base(position, configurationService, view, isObstacle)
        { }
        
        public override void SteppedOn(IInteractableObject2D interactableObject2D)
        {
            
        }
        
        public override void Step(IObject2D staticObject)
        {
            View.UpdatePosition(Position);
        }
        
        public override void Delete()
        {
            
        }
        
        public override void Dispose()
        {
            
        }
    }
}
