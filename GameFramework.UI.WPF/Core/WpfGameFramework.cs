using System.Threading;
using GameFramework.Impl.Core;
using GameFramework.Tiles.Factories;
using GameFramework.UI.WPF.Factories;
using GameFramework.Visuals.Factories;
using Implementation.Module;
using Infrastructure.Module;
using Microsoft.Extensions.DependencyInjection;

namespace GameFramework.UI.WPF.Core
{
    public class WpfGameFramework : AModule, ICancellableModule, IBaseModule
    {
        public CancellationTokenSource Source { get; }

        public WpfGameFramework(IServiceCollection collection, CancellationTokenSource source) : base(collection)
        {
            Source = source;
        }
        
        public override IModule RegisterServices(IServiceCollection collection)
        {
            collection.AddSingleton<ITileViewFactory2D, WpfTileViewFactory>();
            collection.AddSingleton<IMapViewFactory2D, WpfGameMapViewFactory2D>();
            RegisterOtherServices(new GameFrameworkCore(collection, Source));
            return this;
        }
    }
}
