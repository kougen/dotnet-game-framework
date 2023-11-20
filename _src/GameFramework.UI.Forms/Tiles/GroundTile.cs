using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Entities;

namespace GameFramework.UI.Forms.Tiles
{
    public class GroundTile : AFocusableTile
    {
        public override bool IsObstacle => false;
        
        public override void SteppedOn(IUnit2D unit2D)
        {
            throw new NotImplementedException();
        }

        public GroundTile(IPosition2D position, IConfigurationService2D configurationService) : base(position, configurationService, Color.Green)
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

        public override void OnFocused()
        {
            base.OnFocused();
            BorderStyle = IsTileFocused ? BorderStyle.FixedSingle : BorderStyle.None;
        }

        public override void OnFocusLost()
        {
            base.OnFocusLost();
            BorderStyle = IsTileFocused ? BorderStyle.FixedSingle : BorderStyle.None;
        }
    }
}
