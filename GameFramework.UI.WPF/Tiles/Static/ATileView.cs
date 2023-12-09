using System.Windows;
using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Impl.Core.Position;
using GameFramework.Visuals.Views;
using Color = System.Drawing.Color;
using Point = System.Windows.Point;
using Size = System.Windows.Size;

namespace GameFramework.UI.WPF.Tiles.Static
{
    public abstract class ATileView : ACustomShape, IStaticObjectView2D
    {
        public IScreenSpacePosition ScreenSpacePosition { get; }
        protected Color FillColor;
        protected bool HasBorder;
        protected Color BorderColor = Color.Black;

        protected ATileView(IPosition2D position, IConfigurationService2D configurationService, Color fillColor, bool hasBorder) : base(configurationService)
        {
            Rect = new Rect(new Point(ConfigurationService.Dimension * position.X, ConfigurationService.Dimension * position.Y), new Size(ConfigurationService.Dimension , ConfigurationService.Dimension ));
            FillColor = fillColor;
            HasBorder = hasBorder;
            ScreenSpacePosition = new ScreenSpacePosition(Rect.X, Rect.Y);
            InitializeColor();
        }
        
        private void InitializeColor()
        {
            Fill = new SolidColorBrush(ConvertColor(FillColor));
            if (HasBorder)
            {
                Stroke = new SolidColorBrush();
            }
        }
        
        protected static System.Windows.Media.Color ConvertColor(Color color)
        {
            return System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
        }
    }
}
