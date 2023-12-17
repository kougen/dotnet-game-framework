using System.Drawing;
using GameFramework.Core.Position;

namespace GameFramework.Visuals.Tiles
{
    public interface IObjectView2D : IDisposable
    {
        IPosition2D Position2D { get; set; }
        IScreenSpacePosition ScreenSpacePosition { get; }
        Color FillColor { get; set; }
        bool HasBorder { get; set; }
        void ViewLoaded(); 
        void Attach(IViewLoadedSubscriber subscriber);
        void Attach(IViewDisposedSubscriber subscriber);
    }
}
