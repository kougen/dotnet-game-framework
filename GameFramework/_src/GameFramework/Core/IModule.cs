using Microsoft.Extensions.DependencyInjection;

namespace GameFramework.Core
{
    public interface IModule
    {
        public void LoadModules(IServiceCollection collection);
    }
}
