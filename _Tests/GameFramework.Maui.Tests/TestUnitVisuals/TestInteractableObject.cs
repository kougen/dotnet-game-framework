using GameFramework.Core.Motion;
using GameFramework.Core.Position;
using GameFramework.Impl.Tiles.Interactable;
using GameFramework.Manager;
using GameFramework.UI.Maui.Core;
using Infrastructure.Time.Listeners;
using Color = System.Drawing.Color;

namespace GameFramework.Maui.Tests.TestUnitVisuals
{
    public class TestInteractableObject : InteractableTile, ITickListener
    {
        public TimeSpan ElapsedTime { get; set; }
        private int _round;
        private readonly ICollection<TestSpawnable> _spawnables = new List<TestSpawnable>();


        public TestInteractableObject(IPosition2D position) : base(position, GameApp2D.Current.BoardService, Color.Blue)
        { }

        public void RaiseTick(int round)
        {
            var map = GameApp2D.Current.BoardService.GetActiveMap<GameMap>();
            if (GameApp2D.Current.Manager.State == GameState.InProgress)
            {
                if (_round == 3)
                {
                    var spawnable = new TestSpawnable(Position, GameApp2D.Current.BoardService);
                    map?.Interactables.Add(spawnable);
                    _spawnables.Add(spawnable);
                }
                
                if(_round == 5)
                {
                    foreach (var spawnable in _spawnables)
                    {
                        map?.Interactables.Remove(spawnable);
                    }
                }
                
                map?.MoveInteractable(this, Move2D.Right);
            }
            
            _round++;
        }
    }
}
