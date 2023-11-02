using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using GameFramework.Configuration;
using GameFramework.Entities;
using GameFramework.GameFeedback;
using GameFramework.Impl.Core.Position;
using GameFramework.Impl.Core.Position.Factories;
using GameFramework.Impl.GameFeedback;
using GameFramework.Impl.Map.Source;
using GameFramework.Impl.Time;
using GameFramework.ManualTests.Desktop.WPF.GameCanvas;
using GameFramework.ManualTests.Desktop.WPF.GameCanvas.TestUnitVisuals;
using GameFramework.Map;
using GameFramework.Map.MapObject;
using GameFramework.Time;
using GameFramework.UI.WPF.Core;
using Microsoft.Extensions.DependencyInjection;

namespace GameFramework.ManualTests.Desktop.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var data = new int[5, 7];
            var mapView = new TestMapView();
            var mapSource = new JsonMapSource2D(GameApp2D.Current.Services, @"C:\Users\JoshH\OneDrive\File\Documents\test.json", data, new List<IUnit2D>(), 7, 5);
            IMap2D map = new TestMap(mapSource, mapView, new PositionFactory());
            Map.Content = map.View;
            GameApp2D.Current.Manager.StartGame(new GameplayFeedback(FeedbackLevel.Info, "Game test started"), map);

            TestMove(map);
        }

        private async static Task TestMove(IHasUnits2D map)
        {
            var unitView = new TestUnitView(new Position2D(0,0), GameApp2D.Current.ConfigurationService);
            var unit = new TestUnit(unitView, new Position2D(0,0));
            map.Units.Add(unit);
            
            var cancellationTokenSource = new CancellationTokenSource();
            using IStopwatch stopwatch = new DefaultStopwatch(cancellationTokenSource.Token);
            stopwatch.Start();
            for (var i = 0; i < 6; i++)
            {
                await stopwatch.WaitAsync(1000, unit);
            }
        }
    }
}
