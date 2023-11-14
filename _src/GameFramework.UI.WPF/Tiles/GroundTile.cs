using System;
using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Entities;
using GameFramework.GameFeedback;
using GameFramework.Manager;
using GameFramework.Visuals;

namespace GameFramework.UI.WPF.Tiles
{
    internal class GroundTile : ATile, IClickable, IFocusable
    {
        private readonly IGameManager _gameManager;
        public override bool IsObstacle => false;

        public GroundTile(IPosition2D position, IConfigurationService2D configurationService, IGameManager gameManager) : base(position, configurationService)
        {
            _gameManager = gameManager ?? throw new ArgumentNullException(nameof(gameManager));
            Fill = new SolidColorBrush(Colors.Green);
        }

        public override void SteppedOn(IUnit2D unit2D)
        {
            if (_gameManager.State == GameState.InProgress)
            {
                unit2D.Step(this);
            }
        }
        
        public override void OnHovered()
        {
            base.OnHovered();
            Fill = new SolidColorBrush(Colors.LightGreen);
        }

        public override void OnHoverLost()
        {
            base.OnHoverLost();
            Fill = new SolidColorBrush(Colors.Green);
        }

        public bool IsClickEnabled { get; set; }
        
        public void OnClicked()
        {
            
        }
        
        public void OnFocused()
        {
            Stroke = new SolidColorBrush(Colors.Maroon);
            StrokeThickness = 1;
        }
        
        public void OnFocusLost()
        {
            Stroke = new SolidColorBrush(Colors.Transparent);
            StrokeThickness = 0;
        }
    }
}
