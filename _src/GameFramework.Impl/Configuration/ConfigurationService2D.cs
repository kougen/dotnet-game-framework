using GameFramework.Configuration;
using GameFramework.Map;
using GameFramework.Visuals;
using Infrastructure.Application;
using Infrastructure.Configuration;
using Infrastructure.Configuration.Factories;

namespace GameFramework.Impl.Configuration
{
    internal class ConfigurationService2D : IConfigurationService2D
    {
        public CancellationTokenSource CancellationTokenSource { get; }
        private readonly IConfigurationQuery _configurationQuery;
        private IMap2D<IMapSource2D, IMapView2D>? _activeMap;

        public int Dimension
        {
            get => GetDimension();
            set => _configurationQuery.SetAttribute("config.dimension", value);
        }
        public T? GetActiveMap<T>() where T : IMap2D
        {
            if (_activeMap is T map)
            {
                return map;
            }
            
            return default;
        }

        public ConfigurationService2D(IApplicationSettings applicationSettings, IConfigurationQueryFactory configurationQueryFactory, CancellationTokenSource cancellationTokenSource)
        {
            CancellationTokenSource = cancellationTokenSource ?? throw new ArgumentNullException(nameof(cancellationTokenSource));
            _configurationQuery = configurationQueryFactory.CreateConfigurationQuery(Path.Join(applicationSettings.ConfigurationFolder, "game-settings.json"));
        }

        public void SetActiveMap<T>(T map2D) where T : IMap2D<IMapSource2D, IMapView2D>
        {
            _activeMap = map2D ?? throw new ArgumentNullException(nameof(map2D));
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
