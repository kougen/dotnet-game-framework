using System.Diagnostics;
using BoardTemplate.Game.Game.Tiles;
using GameFramework.Impl.Map.Source;
using GameFramework.Objects.Interactable;
using GameFramework.Objects.Static;

namespace BoardTemplate.Game.Game.Map
{
    public class GameMapSource : JsonMapSource2D<TileTypes>, IGameMapSource
    {
        public GameMapSource(IServiceProvider provider, string filePath, int[,] data, ICollection<IInteractableObject2D> units, int col, int row) : base(provider, filePath, data, units, col, row)
        {
            // NOTE: This constructor is used when creating a new map.
        }

        public GameMapSource(IServiceProvider provider, string filePath) : base(provider, filePath)
        {
            // NOTE: This constructor is used when loading an existing map.
        }

        public override void SaveLayout(IEnumerable<IStaticObject2D> updatedMapObjects, IEnumerable<IInteractableObject2D> updatedUnits)
        {
            base.SaveLayout(updatedMapObjects, updatedUnits);
            
            // NOTE: Add your own save logic here
            Debug.WriteLine("Game saved.");
        }
    }
}
