using System;
using System.Collections.Generic;
using System.Windows.Input;
using BoardTemplate.Game;
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
            var mapView = new GameMapView();
            var gamePlay = new Gameplay(GameApp2D.Current, mapView);
            MapView = mapView;
        }

        [RelayCommand]
        private void OnKeyDown(KeyEventArgs e)
        {
            
        }
    }
}
