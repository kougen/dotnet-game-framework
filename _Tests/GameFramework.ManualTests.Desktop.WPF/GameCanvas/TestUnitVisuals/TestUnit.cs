using System;
using GameFramework.Core;
using GameFramework.Core.Motion;
using GameFramework.Core.Position;
using GameFramework.Entities;
using GameFramework.GameFeedback;
using GameFramework.Impl.Core.Position;
using GameFramework.Manager;
using GameFramework.Map;
using GameFramework.Map.MapObject;
using GameFramework.UI.WPF.Core;
using GameFramework.Visuals;
using Infrastructure.Time.Listeners;

namespace GameFramework.ManualTests.Desktop.WPF.GameCanvas.TestUnitVisuals
{
    public class TestUnit : IUnit2D, ITickListener, IClickable
    {
        public Guid Id { get; }
        public bool IsSelected { get; set; }
        public IPosition2D Position { get; private set; }
        public IScreenSpacePosition ScreenSpacePosition { get; }
        public IDynamicMapObjectView View { get; }
        public bool IsObstacle => false;
        public TimeSpan ElapsedTime { get; set; }

        public TestUnit(IDynamicMapObjectView view, IPosition2D position)
        {
            Position = position;
            Id = Guid.NewGuid();
            View = view;
            ScreenSpacePosition = new ScreenSpacePosition(
                GameApp2D.Current.ConfigurationService.Dimension * Position.X,
                GameApp2D.Current.ConfigurationService.Dimension * Position.Y
            );
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
            var map = GameApp2D.Current.BoardService.GetActiveMap();
            if (GameApp2D.Current.Manager.State == GameState.InProgress)
            {
                map?.MoveUnit(this, Move2D.Right);
            }
        }

        public void Dispose()
        {
            View.Dispose();
        }
        
        public bool IsHovered { get; private set; }
        
        public void OnHovered()
        {
            IsHovered = true;
        }
        
        public void OnHoverLost()
        {
            IsHovered = false;
        }
        public bool IsClickEnabled { get; set; }
        public void OnClicked()
        {
            if (!IsClickEnabled)
            {
                return;
            }
        }
    }
}
