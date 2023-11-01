using System.ComponentModel;
using GameFramework.Core;
using GameFramework.Core.Factories;
using GameFramework.Core.Motion;
using GameFramework.Entities;
using GameFramework.Map;
using GameFramework.Map.MapObject;

namespace GameFramework.Impl.Map
{
    public abstract class AMap2D<T> : IMap2D<T> where T : IMapSource2D
    {
        private readonly IPositionFactory _positionFactory;
        public T MapSource { get; }
        public int SizeX { get; }
        public int SizeY { get; }
        public ICollection<IUnit2D> Units { get; }
        public IEnumerable<IUnit2D> SelectedUnits { get; }
        public IEnumerable<IMapObject2D> MapObjects { get; }
        public IMapObject2D? SelectedObject { get; set; }

        protected AMap2D(T mapSource, IPositionFactory positionFactory)
        {
            _positionFactory = positionFactory ?? throw new ArgumentNullException(nameof(positionFactory));
            MapSource = mapSource ?? throw new ArgumentNullException(nameof(mapSource));
            SizeX = MapSource.ColumnCount;
            SizeY = MapSource.RowCount;
            Units = MapSource.Units;
            MapObjects = MapSource.MapObjects;
            SelectedUnits = new List<IUnit2D>();
        }

        #region MapObjects
        public IEnumerable<IMapObject2D> MapPortion(IPosition2D topLeft, IPosition2D bottomRight)
        {
            var objects = MapObjects.ToArray();
            for (var y = topLeft.Y; y <= bottomRight.Y; y++)
            {
                for (var x = topLeft.X; x <= bottomRight.X; x++)
                {
                    yield return objects[y * SizeX + x];
                }
            }
        }

        public IEnumerable<IMapObject2D> MapPortion(IPosition2D center, int radius)
        {
            var top = center.Y - radius < 0 ? 0 : center.Y - radius;
            var bottom = center.Y + radius >= SizeY ? SizeY - 1 : center.Y + radius;
            var left = center.X - radius < 0 ? 0 : center.X - radius;
            var right = center.X + radius >= SizeX ? SizeX - 1 : center.X + radius;
            var topLeftPos = _positionFactory.CreatePosition(left, top);
            var bottomRightPos = _positionFactory.CreatePosition(right, bottom);
            return MapPortion(topLeftPos, bottomRightPos);
        }
        #endregion


        #region Units
        public IEnumerable<IUnit2D> GetUnitsAtPortion(IEnumerable<IMapObject2D> mapObjects)
        {
            var units = new List<IUnit2D>();
            foreach (var mapObject in mapObjects)
            {
                units.AddRange(Units.Where(unit => unit.Position == mapObject.Position));
            }
            
            return units;
        }

        public IEnumerable<IUnit2D> GetUnitsAtPortion(IPosition2D topLeft, IPosition2D bottomRight)
        {
            var portion = MapPortion(topLeft, bottomRight);
            return GetUnitsAtPortion(portion);
        }
        
        public IEnumerable<TUnit> GetUnitsOfTypeAtPortion<TUnit>(IEnumerable<IMapObject2D> mapObjects) where TUnit : IUnit2D
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<TUnit> GetAllUnitsOfType<TUnit>() where TUnit : IUnit2D
        {
            throw new NotImplementedException();
        }
        
        public TUnit? GetUnit<TUnit>(Guid id) where TUnit : IUnit2D
        {
            foreach (var unit in Units)
            {
                if(unit.Id.Equals(id) && unit is TUnit unit2D)
                {
                    return unit2D;
                }
            }
            
            return default;
        }

        public IUnit2D? GetUnit(Guid id)
        {
            return GetUnit<IUnit2D>(id);
        }

        public virtual void MoveUnit(IUnit2D unit2D, Move2D move)
        {
            var mapObject = SimulateMove(unit2D.Position, move);
            if (mapObject is null || mapObject.IsObstacle)
            {
                return;
            }
            unit2D.Step(mapObject);
        }
        
        public IMapObject2D? SimulateMove(IPosition2D position, Move2D move)
        {
            var objects = MapObjects.ToArray();
            switch (move)
            {
                case Move2D.Forward:
                    if (position.Y - 1 >= 0)
                    {
                        return objects[(position.Y - 1) * SizeX + position.X];
                    }
                    break;
                case Move2D.Backward:
                    if (position.Y + 1 < SizeY)
                    {
                        return objects[(position.Y + 1) * SizeX + position.X];
                    }
                    break;
                case Move2D.Left:
                    if (position.X - 1 >= 0)
                    {
                        return objects[position.Y * SizeX + (position.X - 1)];
                    }
                    break;
                case Move2D.Right:
                    if (position.X + 1 < SizeX)
                    {
                        return objects[position.Y * SizeX + (position.X + 1)];
                    }
                    break;
                default: throw new InvalidEnumArgumentException("Unsupported move!");
            }
            return default;
        }

        public void RegisterUnit(IUnit2D unit2D)
        {
            Units.Add(unit2D);
        }
        #endregion
        
        public void SaveProgress()
        {
            MapSource.SaveLayout(MapObjects, Units);
        }
    }
}
