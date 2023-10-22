using GameFramework.Time.Listeners;

namespace GameFramework.Time
{
    public interface IStopwatch : IDisposable
    {
        TimeSpan Elapsed { get; }
        
        void Wait(int periodInMilliseconds, ITickListener listener);
        
        void Start();
        void Stop();
        void Reset();

        void PeriodicOperation(int periodInMilliseconds, ITickListener listener, CancellationToken cancellationToken);
        
        void AttachListener(ITickListener listener);
    }
}
