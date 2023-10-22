using GameFramework.Impl.Time;
using GameFramework.Time.Listeners;
using Moq;

namespace GameFramework.Unit.Tests.Time
{
    public class StopperTests
    {
        [Fact]
        public void StopperTest()
        {
            var token = new CancellationTokenSource();
            var stopper = new DefaultStopwatch(token.Token);
            var dummyListener = new DummyListener();
            stopper.Start();
            stopper.PeriodicOperation(10000, dummyListener, token.Token);
            Console.ReadLine();
            stopper.Stop();
            Console.ReadLine();
            stopper.Start();
            Console.ReadLine();
            token.Cancel();
        }
    }
}
