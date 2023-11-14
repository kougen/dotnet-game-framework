using GameFramework.Core;

namespace GameFramework.Impl.Core.Position
{
    public class ScreenSpacePosition : IScreenSpacePosition
    {
        public double X { get; }
        public double Y { get; }
        
        public ScreenSpacePosition(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
