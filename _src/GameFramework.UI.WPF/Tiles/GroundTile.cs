using System;
using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Entities;
using GameFramework.GameFeedback;

namespace GameFramework.UI.WPF.Tiles
{
    internal class GroundTile : ATile
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
    }
}
