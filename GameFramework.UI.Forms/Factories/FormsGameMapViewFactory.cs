using GameFramework.UI.Forms.Map;
using GameFramework.Visuals.Factories;
using GameFramework.Visuals.Views;

namespace GameFramework.UI.Forms.Factories;

internal class FormsGameMapViewFactory : IMapViewFactory2D
{
    public T CreateMapView2D<T>() where T : IMapView2D, new()
    {
        return new T();
    }

    public IMapView2D CreateMapView2D()
    {
        return new FormsMapControl();
    }
}