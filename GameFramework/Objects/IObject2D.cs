using System.Drawing;
using GameFramework.Core.Position;
using GameFramework.Objects.Interactable;
using GameFramework.Visuals.Tiles;

namespace GameFramework.Objects
{
    public interface IObject2D
    {
        IPosition2D Position { get; }
        IObjectView2D View { get; }
        Color TileColor { get; }
        bool IsObstacle { get; }
        void SteppedOn(IInteractableObject2D interactableObject2D);
    }
    
}
