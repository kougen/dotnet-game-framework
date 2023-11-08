using GameFramework.GameFeedback;
using GameFramework.Map;
using Infrastructure.Time;

namespace GameFramework.Core
{
    public interface IGameManager
    {
        GameState State { get; }
        
        
        IStopwatch Timer { get; }
        
        // TODO: Implement dimension supported game manager 
        void StartGame<T>(IGameplayFeedback feedback, T map2D) where T : IMap2D;
        void EndGame(IGameplayFeedback feedback, GameResolution resolution);
        void PauseGame();
        void ResumeGame();
        void ResetGame();
        
        void AttachListener(IGameManagerSubscriber listener);
    }
}
