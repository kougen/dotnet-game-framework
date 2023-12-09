using BoardTemplate.Game;
using BoardTemplate.Game.Game.Map;
using BoardTemplate.Maui.Map;
using GameFramework.UI.Maui.Core;

namespace BoardTemplate.Maui.ViewModels
{
    public class MainPageViewModel
    {
        public IGameMapView MapControl { get; set; }

        public MainPageViewModel()
        {
            var mapControl = new GameMapView();
            var gameplay = new Gameplay(GameApp2D.Current, mapControl);
            MapControl = mapControl;
        }
    }
}
