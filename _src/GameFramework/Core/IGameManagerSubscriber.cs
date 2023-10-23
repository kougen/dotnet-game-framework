using GameFramework.GameFeedback;

namespace GameFramework.Core
{
    public interface IGameManagerSubscriber
    {
        void OnGameStarted(IGameplayFeedback feedback);
        void OnGameFinished(IGameplayFeedback feedback, GameResolution resolution);
        void OnGamePaused();
        void OnGameResumed();
        void OnGameReset();
    }
}
