using System;
using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Core.Position;
using GameFramework.Entities;
using GameFramework.Manager;
using GameFramework.UI.WPF.Tiles;

namespace GameFramework.WPF.Game.Tiles
{
    // NOTE: There are 4 types of abstract classes: ATile, AHoverableTile, AClickableTile, AFocusableTile, AUnitTile.
    internal class GroundTile : AFocusableTile
    {
        private readonly IGameManager _gameManager;
        public override bool IsObstacle => false;

        // NOTE: You can set border and color here.
        public GroundTile(IPosition2D position, IConfigurationService2D configurationService, IGameManager gameManager) : base(position, configurationService, Colors.Green, hasBorder: true)
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
