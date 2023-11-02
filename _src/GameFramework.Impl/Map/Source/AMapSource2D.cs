using GameFramework.Entities;
using GameFramework.Map;
using GameFramework.Map.MapObject;

namespace GameFramework.Impl.Map.Source
{
    public abstract class AMapSource2D : IMapSource2D
    {
        public Guid Id { get; } = Guid.NewGuid();
        public int ColumnCount { get; set; }
        public int RowCount { get; set; }
        public abstract IEnumerable<IMapObject2D> MapObjects { get; protected set; }
        public abstract ICollection<IUnit2D> Units { get; protected set;}
        
        public abstract void SaveLayout(IEnumerable<IMapObject2D> updatedMapObjects, IEnumerable<IUnit2D> updatedUnits);
    }
}
