using BoardTemplate.Game;
using BoardTemplate.Game.Visuals;
using BoardTemplate.Maui.Map;
using CommunityToolkit.Mvvm.Input;
using GameFramework.UI.Maui.Core;

namespace BoardTemplate.Maui.ViewModels
{
    public partial class MainPageViewModel
    {
        private readonly Gameplay _gameplay;
        public IGameMapView MapControl { get; set; }

        public MainPageViewModel()
        {
            var mapControl = new GameMapView();
            _gameplay = new Gameplay();
            MapControl = mapControl;
        }
        
        [RelayCommand]
        private void OnSaveMap()
        {
            _gameplay?.SaveGame();
        }

        [RelayCommand]
        private void OnLeftButton()
        {
            _gameplay?.HandleKeyPress('a');
        }
        
        [RelayCommand]
        private void OnRightButton()
        {
            _gameplay?.HandleKeyPress('d');
        }
        
        [RelayCommand]
        private void OnUpButton()
        {
            _gameplay?.HandleKeyPress('w');
        }
        
        [RelayCommand]
        private void OnDownButton()
        {
            _gameplay?.HandleKeyPress('s');
        }
        
        [RelayCommand]
        private void OnPauseButton()
        {
            
        }
    }
}
