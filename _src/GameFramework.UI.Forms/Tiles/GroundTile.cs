using GameFramework.Configuration;
using GameFramework.Core.Position;

namespace GameFramework.UI.Forms.Tiles
{
    public class GroundTile : AHoverableTile
    {
        public override bool IsObstacle => false;

        public GroundTile(IPosition2D position, IConfigurationService2D configurationService) : base(position, configurationService, Color.Green, true)
        { }
        
        public override void OnHovered()
        {
            base.OnHovered();
            BackColor = Color.LightGreen;
        }
        
        public override void OnHoverLost()
        {
            base.OnHoverLost();
            BackColor = Color.Green;
        }
    }
}
