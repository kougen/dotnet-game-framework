using System;
using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Core.Position;
using GameFramework.Entities;
using GameFramework.Manager;

namespace GameFramework.UI.WPF.Tiles
{
    internal class GroundTile : AFocusableTile
    {
        private readonly IGameManager _gameManager;
        public override bool IsObstacle => false;

        public GroundTile(IPosition2D position, IConfigurationService2D configurationService, IGameManager gameManager, bool hasBorder = true) : base(position, configurationService, Colors.Green, hasBorder)
        {
            _gameManager = gameManager ?? throw new ArgumentNullException(nameof(gameManager));
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
    }
}
