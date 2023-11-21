using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Entities;
using GameFramework.UI.WPF.Tiles;

namespace GameFramework.WPF.Game.Units
{
    internal class CirclingUnit : AUnitTile
    {
        public CirclingUnit(IPosition2D position, IConfigurationService2D configurationService, Color color, bool hasBorder) : base(position, configurationService, color, hasBorder)
        { }
        
        public override void SteppedOn(IUnit2D unit2D)
        {
            throw new System.NotImplementedException();
        }
    }
}
