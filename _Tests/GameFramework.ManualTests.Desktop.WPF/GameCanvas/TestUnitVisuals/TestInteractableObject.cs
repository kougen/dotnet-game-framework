using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using GameFramework.Core.Motion;
using GameFramework.Core.Position;
using GameFramework.Impl.Tiles.Interactable;
using GameFramework.Manager;
using GameFramework.UI.WPF.Core;
using Infrastructure.Time.Listeners;

namespace GameFramework.ManualTests.Desktop.WPF.GameCanvas.TestUnitVisuals
{
    public class TestInteractableObject : InteractableTile, ITickListener
    {
        public TimeSpan ElapsedTime { get; set; }
        private int _round;
        
        private readonly ICollection<TestSpawnable> _spawnables = new List<TestSpawnable>();
        private readonly TestMap? _map;

        public TestInteractableObject(IPosition2D position) : base(position, GameApp2D.Current.BoardService, Color.Blue)
        {
            _map = GameApp2D.Current.BoardService.GetActiveMap<TestMap>();
        }

        public void DoStep()
        {
            GameApp2D.Current.Manager.Timer.PeriodicOperation(1000, this, new CancellationToken());
        }

        public void RaiseTick(int round)
        {
            var map = GameApp2D.Current.BoardService.GetActiveMap<TestMap>();
            if (GameApp2D.Current.Manager.State == GameState.InProgress)
            {
                if (_round == 2)
                {
                    // var spawnable = new TestSpawnable(Position, GameApp2D.Current.BoardService);
                    // _spawnables.Add(spawnable);
                    // map?.Interactables.Add(spawnable);
                }
                else if (_round == 4)
                {
                    foreach (var spawnable in _spawnables)
                    {
                        map?.Interactables.Remove(spawnable);
                    }
                }
                
                map?.MoveInteractable(this, Move2D.Right);
            }

            _round++;
            if(_round == 6)
            {
                _map?.Interactables.Remove(this);
            }
        }
    }
}
