using GameFramework.Board;
using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Manager;

namespace GameFramework.Application
{
    public interface IApplication2D : IHasProvider
    {
        IGameManager Manager { get; }
        IConfigurationService2D ConfigurationService { get; }
        IBoardService BoardService { get; }
    }
}
