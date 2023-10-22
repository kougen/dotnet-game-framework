using GameFramework.Time.Listeners;

namespace GameFramework.Unit.Tests.Time
{
    public class DummyListener : ITickListener
    {
        public void RaiseTick(int round)
        {
            Console.WriteLine($"Round {round} elapsed time: {ElapsedTime}");
        }

        public TimeSpan ElapsedTime { get; set; }
    }
}