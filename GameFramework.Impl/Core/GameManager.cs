using System.Diagnostics;
using GameFramework.GameFeedback;
using GameFramework.Manager;
using GameFramework.Manager.State;
using Infrastructure.Time;

namespace GameFramework.Impl.Core
{
    internal class GameManager : IGameManager
    {
        private readonly ICollection<IGameStateChangedListener> _listeners;

        public GameState State { get; private set; }
        public IStopwatch Timer { get; }

        public GameManager(IStopwatch stopwatch)
        {
            Timer = stopwatch ?? throw new ArgumentNullException(nameof(stopwatch));
            _listeners = new List<IGameStateChangedListener>();
            State = GameState.NotStarted;
        }
        
        public void StartGame(IGameplayFeedback feedback)
        {
            if(State is GameState.InProgress)
            {
                Debug.WriteLine("Game is already in progress. Cannot start.");
                return;
            }
            
            Timer.Start();
            State = GameState.InProgress;

            foreach (var gameFeedbackListener in _listeners)
            {
                gameFeedbackListener.OnGameStarted(feedback);
            }
        }
        
        public void EndGame(IGameplayFeedback feedback, GameResolution resolution)
        {
            if(State is GameState.Finished or GameState.NotStarted)
            {
                Debug.WriteLine("Game is not in progress. Cannot end.");
                return;
            }
            
            Timer.Stop();
            State = GameState.Finished;

            foreach (var gameFeedbackListener in _listeners)
            {
                gameFeedbackListener.OnGameFinished(feedback, resolution);
            }
        }
        
        public void PauseGame()
        {
            if (State is GameState.Finished or GameState.NotStarted)
            {
                Debug.WriteLine("Game is not in progress. Cannot pause.");
                return;
            }
            Timer.Stop();
            State = GameState.Paused;
            foreach (var gameFeedbackListener in _listeners)
            {
                gameFeedbackListener.OnGamePaused();
            }
        }
        
        public void ResumeGame()
        {
            if (State is GameState.Finished or GameState.NotStarted)
            {
                Debug.WriteLine("Game is not in progress or paused. Cannot resume.");
                return;
            }
            
            Timer.Start();
            State = GameState.InProgress;
            foreach (var gameFeedbackListener in _listeners)
            {
                gameFeedbackListener.OnGameResumed();
            }
        }
        
        public void ResetGame()
        {
            if (State is GameState.NotStarted)
            {
                Debug.WriteLine("Game is not in progress. Cannot reset.");
                return;
            }
            Timer.Reset();
            State = GameState.NotStarted;
            foreach (var gameFeedbackListener in _listeners)
            {
                gameFeedbackListener.OnGameReset();
            }
        }

        public void AttachListener(IGameStateChangedListener changedListener)
        {
            _listeners.Add(changedListener);
        }
    }
}
