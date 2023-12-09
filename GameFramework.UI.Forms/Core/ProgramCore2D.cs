using GameFramework.Application;
using GameFramework.Board;
using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Manager;
using Microsoft.Extensions.DependencyInjection;

namespace GameFramework.UI.Forms.Core
{
    public abstract class ProgramCore2D : IApplication2D
    {
        public IServiceProvider Services { get; }
        public IGameManager Manager { get; }
        public IConfigurationService2D ConfigurationService { get; }
        public IBoardService BoardService { get; }

        protected ProgramCore2D()
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
