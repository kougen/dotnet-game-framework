using GameFramework.Configuration;

namespace GameFramework.Impl.Configuration
{
    internal class ConfigurationService : IConfigurationService
    {
        public int Dimension { get; }
        public ConfigurationService(int dimension)
        {
            Dimension = dimension;
        }
    }
}
