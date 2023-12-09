using GameFramework.Visuals.Views;

namespace GameFramework.Visuals.Factories;

public interface IMapViewFactory2D
{
    T CreateMapView2D<T>() where T : IMapView2D, new();
    IMapView2D CreateMapView2D();
}