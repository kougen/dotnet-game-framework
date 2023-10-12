using GameFramework.Configuration;
using GameFramework.Map;
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
        
        public bool GameIsRunning { get; set; }
        public IMap2D? ActiveMap { get; private set; }

        public ConfigurationService2D(IApplicationSettings applicationSettings, IConfigurationQueryFactory configurationQueryFactory)
        {
            _configurationQuery = configurationQueryFactory.CreateConfigurationQuery(Path.Join(applicationSettings.ConfigurationFolder, "game-settings.json"));
            GameIsRunning = false;
        }
        
        public void SetActiveMap(IMap2D map2D)
        {
            ActiveMap = map2D ?? throw new ArgumentNullException(nameof(map2D));
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
