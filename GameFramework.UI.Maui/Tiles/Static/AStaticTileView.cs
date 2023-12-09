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
        protected System.Drawing.Color FillColor;
        protected bool HasBorder;

        protected AStaticTileView(IPosition2D position, IConfigurationService2D configurationService, System.Drawing.Color fillColor, bool hasBorder)
        {
            ConfigurationService = configurationService ?? throw new ArgumentNullException(nameof(configurationService));
            FillColor = fillColor;
            WidthRequest = ConfigurationService.Dimension;
            HeightRequest = ConfigurationService.Dimension;
            Background = new SolidColorBrush(ConvertColor(FillColor));
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
        
        protected static Color ConvertColor(System.Drawing.Color color)
        {
            return Color.FromRgba(color.R, color.G, color.B, color.A);
        }
    }
}
