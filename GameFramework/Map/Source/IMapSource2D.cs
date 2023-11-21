using GameFramework.Objects;

namespace GameFramework.Map.Source
{
    public interface IMapSource2D
    {
        Guid Id { get; }
        int ColumnCount { get; set; }
        int RowCount { get; set; }
        IEnumerable<IStaticObject2D> MapObjects { get; }
        ICollection<IInteractableObject2D> Units { get; }

        void SaveLayout(IEnumerable<IStaticObject2D> updatedMapObjects, IEnumerable<IInteractableObject2D> updatedUnits);
    }
}
