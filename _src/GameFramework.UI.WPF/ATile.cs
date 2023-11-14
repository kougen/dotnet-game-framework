using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Core.Position;
using GameFramework.Entities;
using GameFramework.Impl.Core.Position;
using GameFramework.Map.MapObject;

namespace GameFramework.UI.WPF
{
    public abstract class ATile : ACustomShape, IMapObject2D
    {
        public IPosition2D Position { get; }
        public IScreenSpacePosition ScreenSpacePosition { get; }
        public abstract bool IsObstacle { get; }
        protected virtual bool HasBorder { get; }
        protected virtual Color BorderColor { get; set; } = Colors.Black;

        protected ATile(IPosition2D position, IConfigurationService2D configurationService, Color fillColor, bool hasBorder) : base(configurationService)
        {
            Position = position ?? throw new ArgumentNullException(nameof(position));
            Rect = new Rect(new Point(ConfigurationService.Dimension * Position.X, ConfigurationService.Dimension * Position.Y), new Size(ConfigurationService.Dimension , ConfigurationService.Dimension ));
            Fill = new SolidColorBrush(fillColor);
            ScreenSpacePosition = new ScreenSpacePosition(Rect.X, Rect.Y);
            HasBorder = hasBorder;
            InitializeColor();
        }
        
        public abstract void SteppedOn(IUnit2D unit2D);
        
        private void InitializeColor()
        {
            if (HasBorder)
            {
                Stroke = new SolidColorBrush(BorderColor);
            }
        }
    }
}
