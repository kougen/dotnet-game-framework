using System;
using System.Windows;
using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Entities;
using GameFramework.Map.MapObject;

namespace GameFramework.UI.WPF
{
    public abstract class ATile : ACustomShape, IMapObject2D
    {
        public IPosition2D Position { get; }
        public abstract bool IsObstacle { get; }
        
        protected ATile(IPosition2D position, IConfigurationService2D configurationService) : base(configurationService)
        {
            Position = position ?? throw new ArgumentNullException(nameof(position));
            Rect = new Rect(new Point(ConfigurationService.Dimension * Position.X, ConfigurationService.Dimension * Position.Y), new Size(ConfigurationService.Dimension , ConfigurationService.Dimension ));
            Fill = new SolidColorBrush(Colors.Black);
        }
        
        public abstract void SteppedOn(IUnit2D unit2D);
    }
}
