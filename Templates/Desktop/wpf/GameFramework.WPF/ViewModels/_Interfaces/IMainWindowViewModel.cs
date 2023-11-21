using GameFramework.WPF.Game.Map;

namespace GameFramework.WPF.ViewModels
{
    public interface IMainWindowViewModel
    {
        IGameMapView MapView { get; }
    }
}
