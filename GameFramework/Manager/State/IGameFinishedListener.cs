using GameFramework.GameFeedback;

namespace GameFramework.Manager.State
{
    public interface IGameFinishedListener
    {
        void OnGameFinished(IGameplayFeedback feedback, GameResolution resolution);
    }
}
