using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Core.Factories;
using GameFramework.Impl.Configuration;
using GameFramework.Impl.Core.Position.Factories;
using GameFramework.Impl.Time;
using GameFramework.Time;
using Infrastructure.Application;
using Infrastructure.Configuration.Factories;
using Infrastructure.Module;
using Microsoft.Extensions.DependencyInjection;

namespace GameFramework.Impl.Core
{
    public class GameModule : IModule
    {
        public void LoadModules(IServiceCollection collection, CancellationTokenSource cancellationTokenSource)
        {
            collection.AddSingleton<IConfigurationService2D, ConfigurationService2D>(p =>
            {
                var appSettings = p.GetRequiredService<IApplicationSettings>();
                var confQueryFactory = p.GetRequiredService<IConfigurationQueryFactory>();
                return new ConfigurationService2D(appSettings, confQueryFactory, cancellationTokenSource);
            });

            collection.AddSingleton<IStopwatch>(_ => new DefaultStopwatch(cancellationTokenSource.Token));
            LoadModules(collection);
        }
        
        public void LoadModules(IServiceCollection collection)
        {
            collection.AddSingleton<IPositionFactory, PositionFactory>();
        }
    }
}
