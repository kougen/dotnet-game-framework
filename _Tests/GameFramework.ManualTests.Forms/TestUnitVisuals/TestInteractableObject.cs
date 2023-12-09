using GameFramework.Configuration;
using GameFramework.Core.Motion;
using GameFramework.Core.Position;
using GameFramework.Impl.Tiles.Interactable;
using GameFramework.Manager;
using GameFramework.ManualTests.Forms.Map;
using GameFramework.Objects;
using GameFramework.Visuals.Views;
using Infrastructure.Time.Listeners;

namespace GameFramework.ManualTests.Forms.TestUnitVisuals
{
    public class TestInteractableObject : GeneralInteractableTile, ITickListener
    {
        public TimeSpan ElapsedTime { get; set; }
        
        public TestInteractableObject(IPosition2D position, IMovingObjectView view) : base(position, Program.Application.ConfigurationService, view, false)
        { }
        
        public override void Step(IObject2D staticObject)
        {
            Position = staticObject.Position;
            View.UpdatePosition(Position);
        }

        public void RaiseTick(int round)
        {
            var map = Program.Application.BoardService.GetActiveMap<TestMap>();
            if (Program.Application.Manager.State == GameState.InProgress)
            {
                map?.MoveInteractable(this, Move2D.Right);
            }
        }
    }
}
