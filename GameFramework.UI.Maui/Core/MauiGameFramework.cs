using GameFramework.UI.Maui.Factories;
using GameFramework.Visuals.Factories;
using Implementation.Module;
using Infrastructure.Module;

namespace GameFramework.UI.Maui.Core;

public class MauiGameFramework : AModule, ICancellableModule, IBaseModule
{
    public CancellationTokenSource Source { get; }

    public MauiGameFramework(IServiceCollection collection, CancellationTokenSource source) : base(collection)
    {
        Source = source ?? throw new ArgumentNullException(nameof(source));
    }

    public override IModule RegisterServices(IServiceCollection collection)
    {
        collection.AddSingleton<ITileViewFactory2D, MauiTileViewFactory>();
        collection.AddSingleton<IMapViewFactory2D, MauiGameMapViewFactory2D>();
        
        return this;
    }

}