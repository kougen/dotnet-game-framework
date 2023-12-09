using GameFramework.Core.Motion;
using GameFramework.Core.Position;
using GameFramework.Impl.Tiles.Interactable;
using GameFramework.Manager;
using GameFramework.Objects;
using GameFramework.UI.Maui.Core;
using GameFramework.Visuals.Views;
using Infrastructure.Time.Listeners;

namespace GameFramework.Maui.Tests.TestUnitVisuals
{
    public class TestInteractableObject : GeneralInteractableTile, ITickListener
    {
        public TimeSpan ElapsedTime { get; set; }

        public TestInteractableObject(IMovingObjectView view, IPosition2D position) : base(position, GameApp2D.Current.ConfigurationService, view)
        { }
        
        public override void Step(IObject2D staticObject)
        {
            Position = staticObject.Position;
            View.UpdatePosition(Position);
        }

        public void RaiseTick(int round)
        {
            var map = GameApp2D.Current.BoardService.GetActiveMap<GameMap>();
            if (GameApp2D.Current.Manager.State == GameState.InProgress)
            {
                map?.MoveInteractable(this, Move2D.Right);
            }
        }
    }
}
