using System.Diagnostics;
using GameFramework.Entities;
using GameFramework.Forms.Game.Tiles;
using GameFramework.Impl.Map.Source;
using GameFramework.Map.MapObject;

namespace GameFramework.Forms.Game.Map
{
    internal class GameMapSource : JsonMapSource2D<TileTypes>, IGameMapSource
    {
        public GameMapSource(IServiceProvider provider, string filePath, int[,] data, ICollection<IUnit2D> units, int col, int row) : base(provider, filePath, data, units, col, row)
        {
            // NOTE: This constructor is used when creating a new map.
        }

        public GameMapSource(IServiceProvider provider, string filePath) : base(provider, filePath)
        {
            // NOTE: This constructor is used when loading an existing map.
        }

        public override void SaveLayout(IEnumerable<IMapObject2D> updatedMapObjects, IEnumerable<IUnit2D> updatedUnits)
        {
            base.SaveLayout(updatedMapObjects, updatedUnits);
            
            // NOTE: Add your own save logic here
            Debug.WriteLine("Game saved.");
        }
    }
}
