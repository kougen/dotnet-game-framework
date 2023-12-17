using GameFramework.Configuration;
using Infrastructure.Application;
using Infrastructure.Configuration;
using Infrastructure.Configuration.Factories;

namespace GameFramework.Impl.Configuration
{
    internal class ConfigurationService2D : IConfigurationService2D
    {
        private readonly IConfigurationQuery _configurationQuery;

        public int Dimension
        {
            get => GetDimension();
            set => _configurationQuery.SetAttribute("config.dimension", value);
        }
      

        public ConfigurationService2D(IApplicationSettings applicationSettings, IConfigurationQueryFactory configurationQueryFactory)
        {
            _configurationQuery = configurationQueryFactory.CreateConfigurationQuery(Path.Join(applicationSettings.ConfigurationFolder, "game-settings.json"));

        }

        private int GetDimension()
        {
            var dimension = _configurationQuery.GetIntAttribute("config.dimension");
            if (dimension is null)
            {
                Dimension = 30;
                return 30;
            }
            return (int)dimension;
        }
    }
}
