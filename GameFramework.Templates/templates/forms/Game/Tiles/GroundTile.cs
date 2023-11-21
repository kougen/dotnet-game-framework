using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Core.Position;
using GameFramework.Entities;
using GameFramework.Manager;
using GameFramework.UI.Forms.Tiles;

namespace GameFramework.Forms.Game.Tiles
{
    // NOTE: There are 4 types of abstract classes: ATile, AHoverableTile, AClickableTile, AFocusableTile, AUnitTile.
    internal class GroundTile : AFocusableTile
    {
        private readonly IGameManager _gameManager;
        public override bool IsObstacle => false;

        // NOTE: You can set border and color here.
        public GroundTile(IPosition2D position, IConfigurationService2D configurationService, IGameManager gameManager) : base(position, configurationService, Color.Green, hasBorder: true)
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
            BackColor = Color.Chartreuse;
        }

        public override void OnHoverLost()
        {
            base.OnHoverLost();
            BackColor = Color.Green;
        }
    }
}
