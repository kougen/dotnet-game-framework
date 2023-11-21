using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Entities;
using GameFramework.UI.Forms.Tiles;

namespace GameFramework.Forms.Game.Units
{
    internal class CirclingUnit : AUnitTile
    {
        public override bool IsObstacle => false;

        public CirclingUnit(IPosition2D position, IConfigurationService2D configurationService, Color color) : base(position, configurationService, color, hasBorder: false)
        { }
        
        public override void SteppedOn(IUnit2D unit2D)
        {
            throw new System.NotImplementedException();
        }
    }
}
