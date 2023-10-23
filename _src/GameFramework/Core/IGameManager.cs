using GameFramework.GameFeedback;
using GameFramework.Time;

namespace GameFramework.Core
{
    public interface IGameManager
    {
        IStopwatch Timer { get; }
        
        void GameStarted(IGameplayFeedback feedback);
        void GameFinished(IGameplayFeedback feedback, GameResolution resolution);
        void GamePaused();
        
        void AttachListener(IGameManagerSubscriber listener);
    }
}
