using GameFramework.Configuration;
using GameFramework.Impl.Core;
using Implementation.Module;
using Microsoft.Extensions.DependencyInjection;

namespace GameFramework.Unit.Tests.Configuration
{
    public class ConfigurationServiceTests
    {
        private readonly ServiceProvider _provider;
        public ConfigurationServiceTests()
        {
            var collection = new ServiceCollection();
            new CoreModule().LoadModules(collection, "game-framework-tests");
            new GameModule().LoadModules(collection);
            _provider = collection.BuildServiceProvider();
        }

        [Fact]
        public void CT_0001()
        {
            var configuration = _provider.GetRequiredService<IConfigurationService2D>();
            configuration.Dimension = 15;
        }
    }
}
