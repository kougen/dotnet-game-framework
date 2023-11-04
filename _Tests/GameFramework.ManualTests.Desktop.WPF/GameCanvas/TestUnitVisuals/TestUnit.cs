using System;
using GameFramework.Core;
using GameFramework.Core.Motion;
using GameFramework.Entities;
using GameFramework.GameFeedback;
using GameFramework.Map;
using GameFramework.Map.MapObject;
using GameFramework.Time.Listeners;
using GameFramework.UI.WPF.Core;
using GameFramework.Visuals;

namespace GameFramework.ManualTests.Desktop.WPF.GameCanvas.TestUnitVisuals
{
    public class TestUnit : IUnit2D, ITickListener
    {
        public Guid Id { get; }
        public IPosition2D Position { get; private set; }
        public IDynamicMapObjectView View { get; }
        public bool IsObstacle => false;
        public TimeSpan ElapsedTime { get; set; }

        public TestUnit(IDynamicMapObjectView view, IPosition2D position)
        {
            Position = position;
            Id = Guid.NewGuid();
            View = view;
        }
        public void SteppedOn(IUnit2D unit2D)
        {
            throw new NotImplementedException();
        }
        
        public void Step(IMapObject2D mapObject)
        {
            Position = mapObject.Position;
            View.UpdatePosition(Position);
        }
        
        public void Kill()
        {
            throw new NotImplementedException();
        }
        
        public void RaiseTick(int round)
        {
            var map = GameApp2D.Current.ConfigurationService.GetActiveMap<IMap2D>();
            if (GameApp2D.Current.Manager.State == GameState.InProgress)
            {
                map?.MoveUnit(this, Move2D.Right);
            }
        }
        
        public void Dispose()
        {
            View.Dispose();
        }
    }
}
