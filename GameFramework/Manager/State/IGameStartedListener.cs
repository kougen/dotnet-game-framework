using GameFramework.GameFeedback;

namespace GameFramework.Manager.State
{
    public interface IGameStartedListener
    {
        void OnGameStarted(IGameplayFeedback feedback);
    }
}
