using GameFramework.Impl.Core;
using GameFramework.UI.Forms.Factories;
using GameFramework.Visuals.Factories;
using Implementation.Module;
using Infrastructure.Module;
using Microsoft.Extensions.DependencyInjection;

namespace GameFramework.UI.Forms.Core;

public class FormsGameFramework : AModule, ICancellableModule, IBaseModule
{
    public CancellationTokenSource Source { get; }

    public FormsGameFramework(IServiceCollection collection, CancellationTokenSource cancellationTokenSource) 
        : base(collection)
    {
        Source = cancellationTokenSource ?? throw new ArgumentNullException(nameof(cancellationTokenSource));
    }

    public override IModule RegisterServices(IServiceCollection collection)
    {
        collection.AddSingleton<ITileViewFactory2D, FormsTileViewFactory>();
        collection.AddSingleton<IMapViewFactory2D, FormsGameMapViewFactory>();

        return this;
    }

}