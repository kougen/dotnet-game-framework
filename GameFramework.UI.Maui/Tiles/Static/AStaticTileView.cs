using System;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Impl.Core.Position;
using GameFramework.Visuals.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace GameFramework.UI.Maui.Tiles.Static
{
    public abstract class AStaticTileView : ContentView, IStaticObjectView2D
    {
        public IScreenSpacePosition ScreenSpacePosition { get; }
        
        protected IConfigurationService2D ConfigurationService { get; }
        protected Color FillColor { get; }
        protected bool HasBorder { get; set; }

        protected AStaticTileView(IPosition2D position, IConfigurationService2D configurationService, Color fillColor, bool hasBorder)
        {
            ConfigurationService = configurationService ?? throw new ArgumentNullException(nameof(configurationService));
            FillColor = fillColor;
            WidthRequest = ConfigurationService.Dimension * position.X;
            HeightRequest = ConfigurationService.Dimension * position.Y;
            Background = new SolidColorBrush(fillColor);
            var rect = new Rect(ConfigurationService.Dimension * position.X, ConfigurationService.Dimension * position.Y, ConfigurationService.Dimension, ConfigurationService.Dimension);
            AbsoluteLayout.SetLayoutBounds(this, rect);
            ScreenSpacePosition = new ScreenSpacePosition(rect.Top, rect.Left);
            HasBorder = hasBorder;
        }
    }
}
