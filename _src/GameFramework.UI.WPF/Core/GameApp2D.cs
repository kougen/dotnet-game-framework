using System;
using System.Windows;
using GameFramework.Board;
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
        public IBoardService BoardService { get; }

        protected GameApp2D()
        {
            var collection = new ServiceCollection();
            Services = LoadModules(collection);
            Manager = Services.GetRequiredService<IGameManager>();
            ConfigurationService = Services.GetRequiredService<IConfigurationService2D>();
            BoardService = Services.GetRequiredService<IBoardService>();
        }

        protected abstract IServiceProvider LoadModules(ServiceCollection collection);
    }
}
