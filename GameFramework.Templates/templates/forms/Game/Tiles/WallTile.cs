using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Entities;
using GameFramework.UI.Forms.Tiles;

namespace GameFramework.Forms.Game.Tiles
{
    internal class WallTile : ATile
    {
        public WallTile(IPosition2D position, IConfigurationService2D configurationService) : base(position, configurationService, Color.Gray)
        { }

        public override bool IsObstacle => true;
        
        public override void SteppedOn(IUnit2D unit2D)
        {
            throw new NotSupportedException();
        }
    }
}
