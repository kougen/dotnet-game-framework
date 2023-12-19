using BoardTemplate.Game.Visuals;

namespace BoardTemplate.WPF.ViewModels
{
    public interface IMainWindowViewModel
    {
        IGameMapView MapView { get; }
    }
}
