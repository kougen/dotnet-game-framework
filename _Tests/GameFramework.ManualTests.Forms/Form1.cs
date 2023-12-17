using GameFramework.GameFeedback;
using GameFramework.Impl.Core.Position;
using GameFramework.Impl.Core.Position.Factories;
using GameFramework.Impl.GameFeedback;
using GameFramework.Impl.Map.Source;
using GameFramework.ManualTests.Forms.Map;
using GameFramework.ManualTests.Forms.TestUnitVisuals;
using GameFramework.Map;
using GameFramework.Objects;
using GameFramework.Objects.Interactable;
using Infrastructure.Time;
using Microsoft.Extensions.DependencyInjection;

namespace GameFramework.ManualTests.Forms
{
    public partial class Form1 : Form
    {
        private readonly TestMap _map;
     
        private static async Task TestMove(IHasIntractable2D map)
        {

            var unit = new TestInteractableObject(new Position2D(0,0));
            map.Interactables.Add(unit);
            
            var stopwatch = Program.Application.Services.GetRequiredService<IStopwatch>();
            stopwatch.Start();
            
            for (var i = 0; i < 6; i++)
            {
                await stopwatch.WaitAsync(1000, unit);
            }
        }
        public Form1()
        {
            InitializeComponent();
            var data = new int[5, 7];
            var mapView = new TestMapView();
            var mapSource = new TestMapSource(Program.Application.Services, @"C:\Users\Dev\Documents\test\test.json", data, new List<IInteractableObject2D>(), 7, 5);
            _map = new TestMap(mapSource, mapView, new PositionFactory(), Program.Application.ConfigurationService);

            Controls.Add(_map.View as Control);
            
            Program.Application.BoardService.SetActiveMap(_map);
            Program.Application.Manager.StartGame(new GameplayFeedback(FeedbackLevel.Info, "Game test started"));
            
            TestMove(_map);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }
    }
}
