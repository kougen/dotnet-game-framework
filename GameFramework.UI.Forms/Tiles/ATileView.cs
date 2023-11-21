using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Impl.Core.Position;
using GameFramework.Visuals.Views;

namespace GameFramework.UI.Forms.Tiles
{
    public abstract class ATileView : UserControl, IStaticObjectView2D
    {
        public IScreenSpacePosition ScreenSpacePosition { get; }
        protected virtual bool HasBorder { get; }
        protected virtual Color BorderColor { get; set; } = Color.Black;
        protected double Size;
        
        protected ATileView(IPosition2D position2D, double size, Color fillColor, bool hasBorder = false)
        {
            Size = size;
            Width = (int)size;
            Height = (int)size;
            Top = (int)size * position2D.Y;
            Left = (int)size * position2D.X;
            var location = PointToScreen(Point.Empty);
            var titleHeight = RectangleToScreen(ClientRectangle).Top - Top;
            ScreenSpacePosition = new ScreenSpacePosition(location.X - 8, location.Y - titleHeight);
            HasBorder = hasBorder;
            InitializeColor(fillColor);
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
