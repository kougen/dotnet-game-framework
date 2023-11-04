using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Entities;

namespace GameFramework.UI.WPF.Tiles
{
    public class GeneralTile : ATile
    {
        public override bool IsObstacle => false;
        public bool IsClickEnabled { get; set; }

        public GeneralTile(IPosition2D position, IConfigurationService2D configurationService, Color color) : base(position, configurationService)
        {
            Fill = new SolidColorBrush(color);
        }
        
        public override void SteppedOn(IUnit2D unit2D)
        {
            
        }
    }
}
