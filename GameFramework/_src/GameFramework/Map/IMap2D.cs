using GameFramework.Entities;
using GameFramework.Map.MapObject;

namespace GameFramework.Map
{
    public interface IMap2D
    {
        public int SizeX { get; }
        public int SizeY { get; }
        public IEnumerable<IPlayer2D> Players { get; }
        public IEnumerable<IMapObject2D> MapObjects { get; }
    }
}
