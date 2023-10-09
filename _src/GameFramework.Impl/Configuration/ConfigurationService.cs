using GameFramework.Configuration;
using Infrastructure.Application;
using Infrastructure.Configuration;
using Infrastructure.Configuration.Factories;

namespace GameFramework.Impl.Configuration
{
    internal class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationQuery _configurationQuery;
        public int Dimension => _configurationQuery.GetIntAttribute("config.dimension") ?? 30;
        
        public ConfigurationService(IApplicationSettings applicationSettings, IConfigurationQueryFactory configurationQueryFactory)
        {
            _configurationQuery = configurationQueryFactory.CreateConfigurationQuery(Path.Join(applicationSettings.ConfigurationFolder, "game-settings.json"));
        }
    }
}
