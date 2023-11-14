using GameFramework.Board;
using GameFramework.Configuration;
using GameFramework.Core;

namespace GameFramework.UI.WPF.Core
{
    public interface IApplication2D : IHasProvider
    {
        IGameManager Manager { get; }
        IConfigurationService2D ConfigurationService { get; }
        IBoardService BoardService { get; }
    }
}
