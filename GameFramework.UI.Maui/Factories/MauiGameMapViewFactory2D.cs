using GameFramework.UI.Maui.Map;
using GameFramework.Visuals.Factories;
using GameFramework.Visuals.Views;

namespace GameFramework.UI.Maui.Factories;

internal class MauiGameMapViewFactory2D : IMapViewFactory2D
{
    public T CreateMapView2D<T>() where T : IMapView2D, new()
    {
        return new T();
    }

    public IMapView2D CreateMapView2D()
    {
        return new MauiMapControl();
    }
}