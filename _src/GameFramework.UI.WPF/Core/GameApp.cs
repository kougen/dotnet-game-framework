using System;
using System.Windows;
using GameFramework.UI.WPF.Core._Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GameFramework.UI.WPF.Core
{
    public abstract class GameApp : Application, IApplication
    {
        public new static IApplication Current => (GameApp)Application.Current;
        
        public IServiceProvider Services { get; }

        protected GameApp()
        {
            var collection = new ServiceCollection();
            Services = LoadModules(collection);
        }

        protected abstract IServiceProvider LoadModules(ServiceCollection collection);
    }
}
