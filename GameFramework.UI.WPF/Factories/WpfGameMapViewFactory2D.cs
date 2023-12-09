using GameFramework.UI.WPF.Map;
using GameFramework.Visuals.Factories;
using GameFramework.Visuals.Views;

namespace GameFramework.UI.WPF.Factories;

internal class WpfGameMapViewFactory2D : IMapViewFactory2D
{
    public T CreateMapView2D<T>() where T : IMapView2D, new()
    {
        return new T();
    }

    public IMapView2D CreateMapView2D()
    {
        return new WpfMapControl();
    }
}