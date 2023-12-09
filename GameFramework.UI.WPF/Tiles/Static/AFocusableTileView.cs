using System.Windows.Controls;
using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Visuals;
using Color = System.Drawing.Color;

namespace GameFramework.UI.WPF.Tiles.Static
{
    public abstract class AFocusableTileView : AClickableTileView, IFocusable
    {
        public virtual bool IsTileFocused { get; protected set; }
        
        protected AFocusableTileView(IPosition2D position, IConfigurationService2D configurationService, Color color, bool hasBorder) : base(position, configurationService, color, hasBorder)
        { }
        
        public virtual void OnFocused()
        {
            IsTileFocused = true;
            Stroke = new SolidColorBrush(ConvertColor(Color.Brown));
            Panel.SetZIndex(this, 1);
            StrokeThickness = 1.5;
        }
        
        public virtual void OnFocusLost()
        {
            IsTileFocused = false;
            Stroke = new SolidColorBrush(ConvertColor(BorderColor));
            Panel.SetZIndex(this, -1);
            StrokeThickness = 1;
        }
    }
}
