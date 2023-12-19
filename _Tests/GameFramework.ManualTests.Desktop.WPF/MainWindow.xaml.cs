using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows;
using GameFramework.GameFeedback;
using GameFramework.Impl.Core.Position;
using GameFramework.Impl.Core.Position.Factories;
using GameFramework.Impl.GameFeedback;
using GameFramework.Manager.State;
using GameFramework.ManualTests.Desktop.WPF.GameCanvas;
using GameFramework.ManualTests.Desktop.WPF.GameCanvas.TestUnitVisuals;
using GameFramework.Map;
using GameFramework.Objects.Interactable;
using GameFramework.UI.WPF.Core;
using Infrastructure.Time;
using Microsoft.Extensions.DependencyInjection;

namespace GameFramework.ManualTests.Desktop.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IGameStartedListener
    {
        private readonly TestMap _map;
        public MainWindow()
        {
            InitializeComponent();
            var data = new int[7, 7];
            var mapView = new TestMapView();
            var mapSource = new TestMapSource(@"C:\Users\Dev\Documents\test\test.json", GameApp2D.Current.Services, 7, 7);
            _map = new TestMap(mapSource, mapView, new PositionFactory(), GameApp2D.Current.ConfigurationService);
            Map.Content = _map.View;
            
            GameApp2D.Current.Manager.AttachListener(this);
            GameApp2D.Current.Manager.StartGame(new GameplayFeedback(FeedbackLevel.Info, "Game test started"));
        }
        
        public void OnGameStarted(IGameplayFeedback feedback)
        {
            GameApp2D.Current.BoardService.SetActiveMap(_map);
            _map.SaveProgress();
        }
    }
}
