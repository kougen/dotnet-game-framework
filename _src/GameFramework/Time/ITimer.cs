using GameFramework.Time.Listeners;

namespace GameFramework.Time
{
    public interface ITimer
    {
        TimeSpan Remaining { get; }
        void AddListener(ITickListener listener);
    }
}
