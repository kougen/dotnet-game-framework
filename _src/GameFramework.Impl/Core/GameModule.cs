using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Core.Factories;
using GameFramework.Impl.Configuration;
using Infrastructure.Module;
using Microsoft.Extensions.DependencyInjection;

namespace GameFramework.Impl.Core
{
    public class GameModule : IModule
    {
        public void LoadModules(IServiceCollection collection)
        {
            collection.AddSingleton<IConfigurationService, ConfigurationService>(_ => new ConfigurationService(30));
            collection.AddSingleton<IPositionFactory, PositionFactory>();
        }
    }
}
