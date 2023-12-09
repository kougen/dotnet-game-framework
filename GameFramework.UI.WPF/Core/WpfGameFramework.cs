using System.Threading;
using GameFramework.Impl.Core;
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
            RegisterOtherServices(new GameFrameworkCore(collection, Source));
            return this;
        }
    }
}
