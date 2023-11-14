namespace GameFramework.Core
{
    public interface IRunningGameListener
    {
        void OnGamePaused();
        void OnGameResumed();
    }
}
