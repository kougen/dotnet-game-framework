using BoardTemplate.Game.Visuals;
using GameFramework.Configuration;
using GameFramework.Core.Position.Factories;
using GameFramework.Impl.Map;

namespace BoardTemplate.Game.Map
{
    public class GameMap : AMap2D<GameMapSource, IGameMapView>
    {
        public GameMap(GameMapSource mapSource, IGameMapView view, IPositionFactory positionFactory, IConfigurationService2D configurationService2D) : base(mapSource, view, positionFactory, configurationService2D)
        { }
    }
}
