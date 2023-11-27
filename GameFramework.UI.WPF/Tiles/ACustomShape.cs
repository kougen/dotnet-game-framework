using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using GameFramework.Configuration;

namespace GameFramework.UI.WPF.Tiles
{
    public abstract class ACustomShape : Shape
    {
        protected IConfigurationService2D ConfigurationService { get; }
        protected Rect Rect;
        protected override Geometry DefiningGeometry => new RectangleGeometry(Rect, 0, 0);

        protected ACustomShape(IConfigurationService2D configurationService)
        {
            ConfigurationService = configurationService ?? throw new ArgumentNullException(nameof(configurationService));
            Rect = new Rect(new Point(0, 0), new Size(ConfigurationService.Dimension , ConfigurationService.Dimension ));
            Fill = new SolidColorBrush(Colors.Black);
        }
        
        protected ACustomShape(IConfigurationService2D configurationService, Rect rect)
        {
            ConfigurationService = configurationService ?? throw new ArgumentNullException(nameof(configurationService));
            Rect = rect;
            Fill = new SolidColorBrush(Colors.Black);
        }
    }
}
