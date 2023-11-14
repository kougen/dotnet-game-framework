using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Visuals;

namespace GameFramework.UI.WPF.Tiles
{
    public abstract class AClickableTile : AHoverableTile, IClickable
    {
        public bool IsClickEnabled { get; set; }

        protected AClickableTile(IPosition2D position, IConfigurationService2D configurationService, Color color, bool hasBorder) : base(position, configurationService, color, hasBorder)
        { }

        public virtual void OnClicked()
        { }
    }
}
