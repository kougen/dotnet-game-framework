using BoardTemplate.Forms.Map;
using GameFramework.Visuals.Factories;
using GameFramework.Visuals.Views;

namespace BoardTemplate.Forms.Factories;

internal class FormsGameMapFactory : IMapViewFactory2D
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