using GameFramework.Core;
using GameFramework.GameFeedback;
using GameFramework.Time;

namespace GameFramework.Impl.Core
{
    internal class GameManager : IGameManager
    {
        private readonly ICollection<IGameManagerSubscriber> _listeners;

        public IStopwatch Timer { get; }
        
        public GameManager(IStopwatch stopwatch)
        {
            Timer = stopwatch ?? throw new ArgumentNullException(nameof(stopwatch));
            _listeners = new List<IGameManagerSubscriber>();
        }
        
        public void GameStarted(IGameplayFeedback feedback)
        {
            Timer.Start();
            foreach (var gameFeedbackListener in _listeners)
            {
                gameFeedbackListener.OnGameStarted(feedback);
            }
        }
        
        public void GameFinished(IGameplayFeedback feedback, GameResolution resolution)
        {
            Timer.Stop();
            foreach (var gameFeedbackListener in _listeners)
            {
                gameFeedbackListener.OnGameFinished(feedback, resolution);
            }
        }
        
        public void GamePaused()
        {
            Timer.Stop();
            foreach (var gameFeedbackListener in _listeners)
            {
                gameFeedbackListener.OnGamePaused();
            }
        }
        
        public void AttachListener(IGameManagerSubscriber listener)
        {
            _listeners.Add(listener);
        }
    }
}
