using GameFramework.Time.Listeners;

namespace GameFramework.Time
{
    public interface IPeriodicStopwatch
    {
        TimeSpan Elapsed { get; }

        void Start();
        void ChangePeriod(int periodInMilliseconds);
        void Stop();
        void Resume();
        void Reset();
        
        void AttachListener(ITickListener listener);
    }
}
