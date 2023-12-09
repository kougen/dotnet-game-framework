using System;
using System.Collections.Generic;
using System.Windows.Input;
using BoardTemplate.Game.Game.Map;
using BoardTemplate.WPF.Map;
using CommunityToolkit.Mvvm.Input;
using GameFramework.Core.Factories;
using GameFramework.GameFeedback;
using GameFramework.Impl.GameFeedback;
using GameFramework.Objects.Interactable;
using GameFramework.UI.WPF.Core;
using Microsoft.Extensions.DependencyInjection;

namespace BoardTemplate.WPF.ViewModels
{
    public partial class MainWindowViewModel : IMainWindowViewModel
    {
        public IGameMapView MapView { get; }

        public MainWindowViewModel()
        {
            const int WIDTH = 5;
            const int HEIGHT = 5;
            var mapSize = new int[HEIGHT, WIDTH];
            
            // NOTE: This is a test map, not the actual map, it has only ground types.
            MapView = new GameMapView();
            var mapSource = new GameMapSource(GameApp2D.Current.Services, @".\test.json", mapSize, new List<IInteractableObject2D>(), WIDTH, HEIGHT);
            var map = new GameMap(mapSource, MapView, GameApp2D.Current.Services.GetRequiredService<IPositionFactory>(), GameApp2D.Current.ConfigurationService);

            // NOTE: This is how you start the game.
            GameApp2D.Current.BoardService.SetActiveMap(map);
            GameApp2D.Current.Manager.StartGame(new GameplayFeedback(FeedbackLevel.Info, "Game test started"));
            
            // NOTE: This is how you save the map.
            map.SaveProgress();
        }

        [RelayCommand]
        private void OnKeyDown(KeyEventArgs e)
        {
            
        }
    }
}
