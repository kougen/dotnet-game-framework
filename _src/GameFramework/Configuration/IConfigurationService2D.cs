using GameFramework.Map;

namespace GameFramework.Configuration
{
    public interface IConfigurationService2D
    {
        int Dimension { get; set; }
        bool GameIsRunning { get; set; }
        
        T? GetActiveMap<T>() where T : IMap2D;
        void SetActiveMap<T>(T map2D) where T : IMap2D;
    }
}
