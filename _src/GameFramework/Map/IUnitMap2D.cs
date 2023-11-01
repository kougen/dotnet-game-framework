using GameFramework.Core;
using GameFramework.Core.Motion;
using GameFramework.Entities;
using GameFramework.Map.MapObject;

namespace GameFramework.Map
{
    public interface IUnitMap2D
    {
        ICollection<IUnit2D> Units { get; }
        IEnumerable<IUnit2D> SelectedUnits { get; }
        
        void MoveUnit(IUnit2D unit2D, Move2D move);
        IMapObject2D? SimulateMove(IPosition2D position, Move2D move);
        IEnumerable<IUnit2D> GetUnitsAtPortion(IEnumerable<IMapObject2D> mapObjects);
        IEnumerable<IUnit2D> GetUnitsAtPortion(IPosition2D topLeft, IPosition2D bottomRight);
        IEnumerable<TUnit> GetUnitsOfTypeAtPortion<TUnit>(IEnumerable<IMapObject2D> mapObjects) where TUnit : IUnit2D;
        IEnumerable<TUnit> GetAllUnitsOfType<TUnit>() where TUnit : IUnit2D;
        TUnit? GetUnit<TUnit>(Guid id) where TUnit : IUnit2D;
        IUnit2D? GetUnit(Guid id);
        void RegisterUnit(IUnit2D unit2D);
    }
}
