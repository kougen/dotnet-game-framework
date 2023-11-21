using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Objects;
using GameFramework.Visuals.Views;

namespace GameFramework.Impl.Tiles.Static
{
    public class GeneralStaticTile : AStaticTile
    {
        public override bool IsObstacle { get; }

        public GeneralStaticTile(IPosition2D position, IConfigurationService2D configurationService, IStaticObjectView2D view, bool isObstacle = false) : base(position, configurationService, view)
        {
            IsObstacle = isObstacle;
        }
        
        public override void SteppedOn(IInteractableObject2D interactableObject2D)
        {
            
        }
    }
}
