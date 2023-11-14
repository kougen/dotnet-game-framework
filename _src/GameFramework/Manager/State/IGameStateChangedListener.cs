using GameFramework.Core;

namespace GameFramework.Manager.State
{
    public interface IGameStateChangedListener : IRunningGameListener, IGameStartedListener, IGameFinishedListener, IGameResetListener
    { }
}
