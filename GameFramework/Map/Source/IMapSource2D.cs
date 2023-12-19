using GameFramework.Objects.Interactable;
using GameFramework.Objects.Static;

namespace GameFramework.Map.Source
{
    public interface IMapSource2D
    {
        Guid Id { get; }
        int ColumnCount { get; set; }
        int RowCount { get; set; }
        bool Initialized { get; }
        IEnumerable<IStaticObject2D> MapObjects { get; }
        ICollection<IInteractableObject2D> Interactables { get; }

        void SaveLayout(IEnumerable<IStaticObject2D> updatedMapObjects, IEnumerable<IInteractableObject2D> updatedUnits);
    }
}
