using BoardTemplate.Game.Game.Map;

namespace BoardTemplate.WPF.ViewModels
{
    public interface IMainWindowViewModel
    {
        IGameMapView MapView { get; }
    }
}
