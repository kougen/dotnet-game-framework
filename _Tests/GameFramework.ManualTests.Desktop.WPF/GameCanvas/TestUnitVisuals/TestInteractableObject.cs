using System;
using System.Collections.Generic;
using System.Drawing;
using GameFramework.Core.Motion;
using GameFramework.Core.Position;
using GameFramework.Impl.Tiles.Interactable;
using GameFramework.Manager;
using GameFramework.Objects;
using GameFramework.UI.WPF.Core;
using GameFramework.Visuals.Tiles;
using GameFramework.Visuals.Views;
using Infrastructure.Time.Listeners;

namespace GameFramework.ManualTests.Desktop.WPF.GameCanvas.TestUnitVisuals
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
            var map = GameApp2D.Current.BoardService.GetActiveMap<TestMap>();
            if (GameApp2D.Current.Manager.State == GameState.InProgress)
            {
                map?.MoveInteractable(this, Move2D.Right);

                if (_round == 3)
                {
                    var spawnable = new TestSpawnable(Position, GameApp2D.Current.BoardService);
                    _spawnables.Add(spawnable);
                    map?.Interactables.Add(spawnable);
                }
                else if (_round == 5)
                {
                    foreach (var spawnable in _spawnables)
                    {
                        map?.Interactables.Remove(spawnable);
                    }
                }
            }

            _round++;
        }
    }
}
