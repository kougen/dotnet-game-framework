using GameFramework.Map;

namespace GameFramework.Configuration
{
    public interface IConfigurationService2D
    {
        int Dimension { get; set; }
        bool GameIsRunning { get; set; }
        IMap2D? ActiveMap { get; }
        void SetActiveMap(IMap2D map2D);
    }
}
