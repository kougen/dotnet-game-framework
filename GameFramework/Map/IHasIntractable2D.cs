using GameFramework.Core.Motion;
using GameFramework.Core.Position;
using GameFramework.Objects;

namespace GameFramework.Map
{
    public interface IHasIntractable2D
    {
        ICollection<IInteractableObject2D> Interactables { get; }
        IEnumerable<IInteractableObject2D> SelectedInteractables { get; }
        
        void MoveInteractable(IInteractableObject2D interactableObject2D, Move2D move);
        IStaticObject2D? SimulateMove(IPosition2D position, Move2D move);
        IEnumerable<IInteractableObject2D> GetInteractablesAtPortion(IStaticObject2D staticObject);
        IEnumerable<IInteractableObject2D> GetInteractablesAtPortion(IEnumerable<IStaticObject2D> mapObjects);
        IEnumerable<IInteractableObject2D> GetInteractablesAtPortion(IPosition2D topLeft, IPosition2D bottomRight);
        IEnumerable<TInteractableObject2D> GetInteractablesOfTypeAtPortion<TInteractableObject2D>(IEnumerable<IStaticObject2D> mapObjects) where TInteractableObject2D : IInteractableObject2D;
        IEnumerable<TInteractableObject2D> GetAllInteractablesOfType<TInteractableObject2D>() where TInteractableObject2D : IInteractableObject2D;
        TInteractableObject2D? GetInteractable<TInteractableObject2D>(Guid id) where TInteractableObject2D : IInteractableObject2D;
        IInteractableObject2D? GetInteractable(Guid id);
    }
}
