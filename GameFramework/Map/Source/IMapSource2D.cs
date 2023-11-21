using GameFramework.Entities;
using GameFramework.Map.MapObject;

namespace GameFramework.Map
{
    public interface IMapSource2D
    {
        Guid Id { get; }
        int ColumnCount { get; set; }
        int RowCount { get; set; }
        IEnumerable<IMapObject2D> MapObjects { get; }
        ICollection<IUnit2D> Units { get; }

        void SaveLayout(IEnumerable<IMapObject2D> updatedMapObjects, IEnumerable<IUnit2D> updatedUnits);
    }
}
