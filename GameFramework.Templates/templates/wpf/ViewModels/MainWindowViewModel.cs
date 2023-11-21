using GameFramework.WPF.Game.Map;

namespace GameFramework.WPF.ViewModels
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        public IGameMapView MapView { get; } = new GameMapView();
    }
}
