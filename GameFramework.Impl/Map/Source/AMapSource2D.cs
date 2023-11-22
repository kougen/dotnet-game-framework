using GameFramework.Map;
using GameFramework.Map.Source;
using GameFramework.Objects;
using GameFramework.Objects.Interactable;
using GameFramework.Objects.Static;

namespace GameFramework.Impl.Map.Source
{
    public abstract class AMapSource2D : IMapSource2D
    {
        public Guid Id { get; } = Guid.NewGuid();
        public int ColumnCount { get; set; }
        public int RowCount { get; set; }
        public abstract IEnumerable<IStaticObject2D> MapObjects { get; protected set; }
        public abstract ICollection<IInteractableObject2D> Units { get; protected set;}
        
        public abstract void SaveLayout(IEnumerable<IStaticObject2D> updatedMapObjects, IEnumerable<IInteractableObject2D> updatedUnits);
    }
}
