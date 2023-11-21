using System.Collections.Generic;
using GameFramework.Core.Factories;
using GameFramework.Entities;
using GameFramework.GameFeedback;
using GameFramework.Impl.GameFeedback;
using GameFramework.UI.WPF.Core;
using GameFramework.WPF.Game.Map;
using Microsoft.Extensions.DependencyInjection;

namespace GameFramework.WPF.ViewModels
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        public IGameMapView MapView { get; }

        public MainWindowViewModel()
        {
            const int WIDTH = 5;
            const int HEIGHT = 5;
            var mapSize = new int[HEIGHT, WIDTH];
            
            // NOTE: This is a test map, not the actual map, it has only ground types.
            MapView = new GameMapView();
            var mapSource = new GameMapSource(GameApp2D.Current.Services, @".\test.json", mapSize, new List<IUnit2D>(), WIDTH, HEIGHT);
            var map = new GameMap(mapSource, MapView, GameApp2D.Current.Services.GetRequiredService<IPositionFactory>(), GameApp2D.Current.ConfigurationService);

            // NOTE: This is how you start the game.
            GameApp2D.Current.BoardService.SetActiveMap(map);
            GameApp2D.Current.Manager.StartGame(new GameplayFeedback(FeedbackLevel.Info, "Game test started"));
            
            // NOTE: This is how you save the map.
            map.SaveProgress();
        }
    }
}
