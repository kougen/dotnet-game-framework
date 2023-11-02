using System;
using System.Windows;
using GameFramework.Configuration;
using GameFramework.Core;
using Microsoft.Extensions.DependencyInjection;

namespace GameFramework.UI.WPF.Core
{
    public abstract class GameApp2D : Application, IApplication2D
    {
        public new static IApplication2D Current => (GameApp2D)Application.Current;
        
        public IServiceProvider Services { get; }
        public IGameManager Manager { get; }
        public IConfigurationService2D ConfigurationService { get; }

        protected GameApp2D()
        {
            var collection = new ServiceCollection();
            Services = LoadModules(collection);
            Manager = Services.GetRequiredService<IGameManager>();
            ConfigurationService = Services.GetRequiredService<IConfigurationService2D>();
        }

        protected abstract IServiceProvider LoadModules(ServiceCollection collection);
    }
}
