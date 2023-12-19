using System.Diagnostics;
using System.Drawing;
using GameFramework.Impl.Map.Source;
using GameFramework.Objects.Interactable;
using GameFramework.Objects.Static;

namespace BoardTemplate.Game.Map
{
    public class GameMapSource : JsonMapSource2D
    {
        public GameMapSource(string filePath, IServiceProvider provider, int col, int row, Color? bgColor = null,
            ICollection<IInteractableObject2D>? interactables = null, bool bypass = false)
            : base(filePath, provider, col, row, bgColor, interactables, bypass)
        {
        }

        public GameMapSource(IServiceProvider provider, int col, int row, Color? bgColor = null,
            ICollection<IInteractableObject2D>? interactables = null, bool bypass = false)
            : base(provider, col, row, bgColor, interactables, bypass)
        {
        }

        public GameMapSource(string filePath, IServiceProvider provider, Color bgColor)
            : base(filePath, provider, bgColor)
        {
        }

        public GameMapSource(IServiceProvider provider, Color bgColor)
            : base(provider, bgColor)
        {
        }

        public override void SaveLayout(IEnumerable<IStaticObject2D> updatedMapObjects,
            IEnumerable<IInteractableObject2D> updatedUnits)
        {
            base.SaveLayout(updatedMapObjects, updatedUnits);

            // NOTE: Add your own save logic here
            Debug.WriteLine("Game saved.");
        }
    }
}