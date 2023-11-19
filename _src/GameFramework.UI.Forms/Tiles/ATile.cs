﻿using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Entities;
using GameFramework.Impl.Core.Position;
using GameFramework.Map.MapObject;

namespace GameFramework.UI.Forms.Tiles
{
    public abstract class ATile : UserControl, IMapObject2D
    {
        public IPosition2D Position { get; }
        public IScreenSpacePosition ScreenSpacePosition { get; }
        public abstract bool IsObstacle { get; }
        
        protected virtual bool HasBorder { get; }
        protected virtual Color BorderColor { get; set; } = Color.Black;
        protected IConfigurationService2D ConfigurationService { get; }

        protected ATile(IPosition2D position, IConfigurationService2D configurationService, Color fillColor, bool hasBorder = false)
        {
            Position = position ?? throw new ArgumentNullException(nameof(position));
            ConfigurationService = configurationService ?? throw new ArgumentNullException(nameof(configurationService));
            Width = configurationService.Dimension;
            Height = configurationService.Dimension;
            Top = configurationService.Dimension * position.Y;
            Left = configurationService.Dimension * position.X;
            ScreenSpacePosition = new ScreenSpacePosition(Left, Top);
            HasBorder = hasBorder;
            InitializeColor(fillColor);
        }
        
        public void SteppedOn(IUnit2D unit2D)
        {
            throw new NotImplementedException();
        }
        
        private void InitializeColor(Color fillColor)
        {
            if (HasBorder)
            {
                BorderStyle = BorderStyle.FixedSingle;
            }
            
            BackColor = fillColor;
        }
    }
}
