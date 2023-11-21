﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using GameFramework.Entities;
using GameFramework.GameFeedback;
using GameFramework.Impl.Core.Position;
using GameFramework.Impl.Core.Position.Factories;
using GameFramework.Impl.GameFeedback;
using GameFramework.Manager;
using GameFramework.Manager.State;
using GameFramework.ManualTests.Desktop.WPF.GameCanvas;
using GameFramework.ManualTests.Desktop.WPF.GameCanvas.TestUnitVisuals;
using GameFramework.Map;
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
            var data = new int[5, 7];
            var mapView = new TestMapView();
            var mapSource = new TestMapSource(GameApp2D.Current.Services, @"C:\Users\JoshH\OneDrive\File\Documents\test.json", data, new List<IUnit2D>(), 7, 5);
            _map = new TestMap(mapSource, mapView, new PositionFactory(), GameApp2D.Current.ConfigurationService);
            Map.Content = _map.View;
            GameApp2D.Current.Manager.StartGame(new GameplayFeedback(FeedbackLevel.Info, "Game test started"));
            
            TestMove(_map);
        }

        private static async Task TestMove(IHasUnits2D map)
        {
            var unitView = new TestUnitView(new Position2D(0,0), GameApp2D.Current.ConfigurationService);
            var unit = new TestUnit(unitView, new Position2D(0,0));
            map.Units.Add(unit);
            
            var stopwatch = GameApp2D.Current.Services.GetRequiredService<IStopwatch>();
            stopwatch.Start();
            
            for (var i = 0; i < 6; i++)
            {
                await stopwatch.WaitAsync(1000, unit);
            }
        }
        
        public void OnGameStarted(IGameplayFeedback feedback)
        {
            GameApp2D.Current.BoardService.SetActiveMap<TestMap, TestMapSource, TestMapView>(_map);
        }
    }
}