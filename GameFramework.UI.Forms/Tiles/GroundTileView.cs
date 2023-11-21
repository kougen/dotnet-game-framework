using GameFramework.Configuration;
using GameFramework.Core.Position;

namespace GameFramework.UI.Forms.Tiles
{
    public class GroundTileView : AFocusableTileView
    {
        public GroundTileView(IPosition2D position, IConfigurationService2D configurationService) : base(position, configurationService.Dimension, Color.Green)
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
