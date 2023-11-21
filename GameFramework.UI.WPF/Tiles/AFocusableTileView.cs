using System.Windows.Controls;
using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Core.Position;
using GameFramework.Visuals;

namespace GameFramework.UI.WPF.Tiles
{
    public abstract class AFocusableTileView : AClickableTileView, IFocusable
    {
        public virtual bool IsTileFocused { get; protected set; }
        
        protected AFocusableTileView(IPosition2D position, IConfigurationService2D configurationService, Color color, bool hasBorder) : base(position, configurationService, color, hasBorder)
        { }
        
        public virtual void OnFocused()
        {
            IsTileFocused = true;
            Stroke = new SolidColorBrush(Colors.Brown);
            Panel.SetZIndex(this, 1);
            StrokeThickness = 1.5;
        }
        
        public virtual void OnFocusLost()
        {
            IsTileFocused = false;
            Stroke = new SolidColorBrush(BorderColor);
            Panel.SetZIndex(this, -1);
            StrokeThickness = 1;
        }
    }
}
