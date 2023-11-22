using System.Windows;
using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Impl.Core.Position;
using GameFramework.Visuals.Views;

namespace GameFramework.UI.WPF.Tiles.Static
{
    public abstract class ATileView : ACustomShape, IStaticObjectView2D
    {
        public IScreenSpacePosition ScreenSpacePosition { get; }
        protected virtual bool HasBorder { get; }
        protected virtual Color BorderColor { get; set; } = Colors.Black;

        protected ATileView(IPosition2D position, IConfigurationService2D configurationService, Color fillColor, bool hasBorder) : base(configurationService)
        {
            Rect = new Rect(new Point(ConfigurationService.Dimension * position.X, ConfigurationService.Dimension * position.Y), new Size(ConfigurationService.Dimension , ConfigurationService.Dimension ));
            Fill = new SolidColorBrush(fillColor);
            ScreenSpacePosition = new ScreenSpacePosition(Rect.X, Rect.Y);
            HasBorder = hasBorder;
            InitializeColor();
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
