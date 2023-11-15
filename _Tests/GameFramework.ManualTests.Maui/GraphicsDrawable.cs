using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.ManualTests.Maui
{
    public class GraphicsDrawable : IDrawable, IMapView2D
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 6;
            canvas.DrawLine(10, 10, 90, 100);
            canvas.Re
        }
    }
}
