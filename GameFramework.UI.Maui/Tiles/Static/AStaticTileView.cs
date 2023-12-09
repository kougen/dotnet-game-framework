using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Impl.Core.Position;
using GameFramework.Visuals.Views;

namespace GameFramework.UI.Maui.Tiles.Static
{
    public abstract class AStaticTileView : BoxView, IStaticObjectView2D
    {
        public IScreenSpacePosition ScreenSpacePosition { get; protected set; }
        
        protected IConfigurationService2D ConfigurationService { get; }
        protected Color FillColor { get; }
        protected bool HasBorder { get; set; }

        protected AStaticTileView(IPosition2D position, IConfigurationService2D configurationService, Color fillColor, bool hasBorder)
        {
            ConfigurationService = configurationService ?? throw new ArgumentNullException(nameof(configurationService));
            FillColor = fillColor;
            WidthRequest = ConfigurationService.Dimension;
            HeightRequest = ConfigurationService.Dimension;
            Background = new SolidColorBrush(fillColor);
            SetPosition(position);
            HasBorder = hasBorder;

            if (ScreenSpacePosition == null)
            {
                throw new ArgumentNullException(nameof(ScreenSpacePosition));
            }
        }
        
        protected void SetPosition(IPosition2D position)
        {
            var rect = new Rect(ConfigurationService.Dimension * position.X, ConfigurationService.Dimension * position.Y, ConfigurationService.Dimension, ConfigurationService.Dimension);
            AbsoluteLayout.SetLayoutBounds(this, rect);
            ScreenSpacePosition = new ScreenSpacePosition(rect.Top, rect.Left);
        }
    }
}
