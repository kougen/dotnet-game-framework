using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Entities;
using GameFramework.Impl.Core.Position;
using GameFramework.Map.MapObject;
using GameFramework.Visuals;

namespace GameFramework.UI.WPF
{
    public abstract class ATile : ACustomShape, IMapObject2D
    {
        public IPosition2D Position { get; }
        public IScreenSpacePosition ScreenSpacePosition { get; }
        public abstract bool IsObstacle { get; }
        public bool IsHovered { get; protected set; }

        protected ATile(IPosition2D position, IConfigurationService2D configurationService) : base(configurationService)
        {
            Position = position ?? throw new ArgumentNullException(nameof(position));
            Rect = new Rect(new Point(ConfigurationService.Dimension * Position.X, ConfigurationService.Dimension * Position.Y), new Size(ConfigurationService.Dimension , ConfigurationService.Dimension ));
            Fill = new SolidColorBrush(Colors.Black);
            ScreenSpacePosition = new ScreenSpacePosition(Rect.X, Rect.Y);
        }
        
        public abstract void SteppedOn(IUnit2D unit2D);

        public virtual void OnHovered()
        {
            IsHovered = true;
        }
        
        public virtual void OnHoverLost()
        {
            IsHovered = false;
        }
    }
}
