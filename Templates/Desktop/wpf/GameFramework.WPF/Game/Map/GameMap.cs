using GameFramework.Configuration;
using GameFramework.Core.Factories;
using GameFramework.Impl.Map;

namespace GameFramework.WPF.Game.Map
{
    internal class GameMap : AMap2D<IGameMapSource, IGameMapView>, IGameMap
    {
        public GameMap(IGameMapSource mapSource, IGameMapView view, IPositionFactory positionFactory, IConfigurationService2D configurationService2D) : base(mapSource, view, positionFactory, configurationService2D)
        { }
    }
}
