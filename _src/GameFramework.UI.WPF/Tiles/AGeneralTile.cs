using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Entities;

namespace GameFramework.UI.WPF.Tiles
{
    public abstract class AGeneralTile : ATile
    {
        protected virtual bool HasBorder { get; }
        public virtual bool IsClickEnabled { get; set; }
        protected virtual Color BorderColor { get; set; } = Colors.Black;

        protected AGeneralTile(IPosition2D position, IConfigurationService2D configurationService, Color color, bool hasBorder) : base(position, configurationService)
        {
            HasBorder = hasBorder;
            Fill = new SolidColorBrush(color);
            
            InitializeColor();
        }
        
        public override void SteppedOn(IUnit2D unit2D)
        {
            
        }

        private void InitializeColor()
        {
            if (HasBorder)
            {
                Stroke = new SolidColorBrush(BorderColor);
            }
        }
     }
}
