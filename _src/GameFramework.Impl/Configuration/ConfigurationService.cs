using GameFramework.Configuration;
using Infrastructure.Application;
using Infrastructure.Configuration;
using Infrastructure.Configuration.Factories;

namespace GameFramework.Impl.Configuration
{
    internal class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationQuery _configurationQuery;
        public int Dimension
        {
            get => _configurationQuery.GetIntAttribute("config.dimension") ?? 30;
            set => _configurationQuery.SetAttribute("config.dimension", value);
        }
        
        public ConfigurationService(IApplicationSettings applicationSettings, IConfigurationQueryFactory configurationQueryFactory)
        {
            _configurationQuery = configurationQueryFactory.CreateConfigurationQuery(Path.Join(applicationSettings.ConfigurationFolder, "game-settings.json"));
        }
    }
}
