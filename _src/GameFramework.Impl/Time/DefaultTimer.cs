using System.Diagnostics;
using GameFramework.Time;
using GameFramework.Time.Listeners;

namespace GameFramework.Impl.Time
{
    internal class DefaultTimer : ITimer
    {
        public TimeSpan Remaining { get; }
        
        public void AddListener(ITickListener listener)
        {
            throw new NotImplementedException();
        }
    }
}
