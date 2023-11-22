using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Impl.Tiles.Static;
using GameFramework.Objects.Interactable;
using GameFramework.Visuals.Views;

namespace BoardTemplate.Game.Tiles
{
    public class HoverableTile : AHoverableStaticTile
    {
        public override bool IsObstacle { get; }

        public HoverableTile(IPosition2D position, IConfigurationService2D configurationService, IStaticObjectView2D view, bool isObstacle = false) : base(position, configurationService, view)
        {
            IsObstacle = isObstacle;
        }
        
        public override void SteppedOn(IInteractableObject2D interactableObject2D)
        {
            
        }
    }
}
