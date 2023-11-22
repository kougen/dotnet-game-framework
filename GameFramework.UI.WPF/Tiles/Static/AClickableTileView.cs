using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Visuals;

namespace GameFramework.UI.WPF.Tiles.Static
{
    public abstract class AClickableTileView : AHoverableTileView, IClickable
    {
        public bool IsClickEnabled { get; set; }

        protected AClickableTileView(IPosition2D position, IConfigurationService2D configurationService, Color color, bool hasBorder) : base(position, configurationService, color, hasBorder)
        { }

        public virtual void OnClicked()
        { }
    }
}
