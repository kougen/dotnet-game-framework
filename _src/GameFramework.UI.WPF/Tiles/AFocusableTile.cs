using System.Windows.Controls;
using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Visuals;

namespace GameFramework.UI.WPF.Tiles
{
    public abstract class AFocusableTile : AGeneralTile, IFocusable
    {
        public virtual bool IsTileFocused { get; protected set; }
        
        protected AFocusableTile(IPosition2D position, IConfigurationService2D configurationService, Color color, bool hasBorder) : base(position, configurationService, color, hasBorder)
        { }
        
        public virtual void OnClicked()
        {
            
        }
        
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
