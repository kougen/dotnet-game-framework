using GameFramework.GameFeedback;
using GameFramework.Manager;
using GameFramework.Manager.State;
using Infrastructure.Time;

namespace GameFramework.Core
{
    public interface IGameManager
    {
        GameState State { get; }
        IStopwatch Timer { get; }
        
        void StartGame(IGameplayFeedback feedback);
        void EndGame(IGameplayFeedback feedback, GameResolution resolution);
        void PauseGame();
        void ResumeGame();
        void ResetGame();
        
        void AttachListener(IGameStateChangedListener changedListener);
    }
}