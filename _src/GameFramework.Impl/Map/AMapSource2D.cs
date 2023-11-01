using GameFramework.Entities;
using GameFramework.Map;
using GameFramework.Map.MapObject;

namespace GameFramework.Impl.Map
{
    public class AMapSource2D : IMapSource2D
    {
        public AMapSource2D()
        {
            
        }
        
        public Guid Id { get; }
        public int ColumnCount { get; set; }
        public int RowCount { get; set; }
        public IEnumerable<IMapObject2D> MapObjects { get; }
        public ICollection<IUnit2D> Units { get; }
        public void SaveLayout(IEnumerable<IMapObject2D> updatedMapObjects, IEnumerable<IUnit2D> updatedUnits)
        {
            
        }
    }
}
