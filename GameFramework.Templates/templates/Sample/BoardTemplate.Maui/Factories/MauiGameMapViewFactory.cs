using BoardTemplate.Maui.Map;
using GameFramework.Visuals.Factories;
using GameFramework.Visuals.Views;

namespace BoardTemplate.Maui.Factories;

internal class MauiGameMapViewFactory : IMapViewFactory2D
{
    public T CreateMapView2D<T>() where T : IMapView2D, new()
    {
        return new T();
    }

    public IMapView2D CreateMapView2D()
    {
        return new GameMapView();
    }
}