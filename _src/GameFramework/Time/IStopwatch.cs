using GameFramework.Time.Listeners;

namespace GameFramework.Time
{
    public interface IStopwatch : IDisposable
    {
        bool IsRunning { get; }
        TimeSpan Elapsed { get; }
        
        void Wait(int periodInMilliseconds, ITickListener listener);
        Task WaitAsync(int periodInMilliseconds, ITickListener listener);
        
        void Start();
        void Stop();
        void Reset();

        void PeriodicOperation(int periodInMilliseconds, ITickListener listener, CancellationToken cancellationToken);
        
        void AttachListener(ITickListener listener);
    }
}
