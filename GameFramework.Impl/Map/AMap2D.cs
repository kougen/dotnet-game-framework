using System.Collections.ObjectModel;
using System.ComponentModel;
using GameFramework.Configuration;
using GameFramework.Core.Motion;
using GameFramework.Core.Position;
using GameFramework.Core.Position.Factories;
using GameFramework.Map;
using GameFramework.Map.Source;
using GameFramework.Objects;
using GameFramework.Objects.Interactable;
using GameFramework.Objects.Static;
using GameFramework.Tiles;
using GameFramework.Visuals;
using GameFramework.Visuals.Handlers;
using GameFramework.Visuals.Tiles;
using GameFramework.Visuals.Views;

namespace GameFramework.Impl.Map
{
    public abstract class AMap2D<TSource, TView> : IMap2D<TSource, TView>, IMouseHandler
        where TSource : class, IMapSource2D
        where TView : class, IMapView2D
    {
        protected readonly IPositionFactory PositionFactory;
        protected readonly IConfigurationService2D ConfigurationService2D;
        private readonly ObservableCollection<IInteractableObject2D> _units;
        private readonly ObservableCollection<IStaticObject2D> _mapObjects;

        public TView View { get; }
        public TSource MapSource { get; }
        public int SizeX { get; }
        public int SizeY { get; }
        public ICollection<IInteractableObject2D> Interactables => _units;
        public virtual IEnumerable<IInteractableObject2D> SelectedInteractables { get; }
        public ICollection<IStaticObject2D> MapObjects => _mapObjects;
        public IObject2D? SelectedObject { get; set; }

        protected AMap2D(TSource mapSource, TView view, IPositionFactory positionFactory, IConfigurationService2D configurationService2D)
        {
            PositionFactory = positionFactory ?? throw new ArgumentNullException(nameof(positionFactory));
            ConfigurationService2D = configurationService2D ?? throw new ArgumentNullException(nameof(configurationService2D));
            MapSource = mapSource ?? throw new ArgumentNullException(nameof(mapSource));
            View = view ?? throw new ArgumentNullException(nameof(view));
            SizeX = MapSource.ColumnCount;
            SizeY = MapSource.RowCount;
            _units = new ObservableCollection<IInteractableObject2D>(MapSource.Interactables);
            View.InteractableObjects = new ObservableCollection<IInteractableObject2D>(Interactables);
            _mapObjects = new ObservableCollection<IStaticObject2D>(MapSource.MapObjects);
            View.MapObjects = new ObservableCollection<IStaticObject2D>(MapObjects);
            SelectedInteractables = new List<IInteractableObject2D>();

            _units.CollectionChanged += (_, _) => View.InteractableObjects = new ObservableCollection<IInteractableObject2D>(Interactables);
            _mapObjects.CollectionChanged += (_, _) => View.MapObjects = new ObservableCollection<IStaticObject2D>(MapObjects);
            View.Attach(this);
        }

        #region MapObjects
        public virtual IEnumerable<IStaticObject2D> MapPortion(IPosition2D topLeft, IPosition2D bottomRight)
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

        public virtual IEnumerable<IStaticObject2D> MapPortion(IPosition2D center, int radius)
        {
            var top = center.Y - radius < 0 ? 0 : center.Y - radius;
            var bottom = center.Y + radius >= SizeY ? SizeY - 1 : center.Y + radius;
            var left = center.X - radius < 0 ? 0 : center.X - radius;
            var right = center.X + radius >= SizeX ? SizeX - 1 : center.X + radius;
            var topLeftPos = PositionFactory.CreatePosition(left, top);
            var bottomRightPos = PositionFactory.CreatePosition(right, bottom);
            return MapPortion(topLeftPos, bottomRightPos);
        }
        #endregion
        
        #region Units
        public IEnumerable<IInteractableObject2D> GetInteractablesAtPortion(IStaticObject2D staticObject)
        {
            return GetInteractablesAtPortion(new[]
            {
                staticObject
            });
        }
        
        public virtual IEnumerable<IInteractableObject2D> GetInteractablesAtPortion(IEnumerable<IStaticObject2D> mapObjects)
        {
            var units = new List<IInteractableObject2D>();
            foreach (var mapObject in mapObjects)
            {
                units.AddRange(Interactables.Where(unit => unit.Position == mapObject.Position));
            }

            return units;
        }

        public virtual IEnumerable<IInteractableObject2D> GetInteractablesAtPortion(IPosition2D topLeft, IPosition2D bottomRight)
        {
            var portion = MapPortion(topLeft, bottomRight);
            return GetInteractablesAtPortion(portion);
        }

        public virtual IEnumerable<TUnit> GetInteractablesOfTypeAtPortion<TUnit>(IEnumerable<IStaticObject2D> mapObjects) where TUnit : IInteractableObject2D
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TUnit> GetAllInteractablesOfType<TUnit>() where TUnit : IInteractableObject2D
        {
            throw new NotImplementedException();
        }

        public virtual TUnit? GetInteractable<TUnit>(Guid id) where TUnit : IInteractableObject2D
        {
            foreach (var unit in Interactables)
            {
                if (unit.Id.Equals(id) && unit is TUnit unit2D)
                {
                    return unit2D;
                }
            }

            return default;
        }

        public virtual IInteractableObject2D? GetInteractable(Guid id)
        {
            return GetInteractable<IInteractableObject2D>(id);
        }

        public virtual void MoveInteractable(IInteractableObject2D interactableObject2D, Move2D move)
        {
            var mapObject = SimulateMove(interactableObject2D.Position, move);
            if (mapObject is null || mapObject.IsObstacle)
            {
                return;
            }

            foreach (var unit in GetInteractablesAtPortion(mapObject))
            {
                interactableObject2D.SteppedOn(unit);
            }
            
            interactableObject2D.Step(mapObject);
        }

        public virtual IStaticObject2D? SimulateMove(IPosition2D position, Move2D move)
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
        
        #endregion

        public virtual void SaveProgress()
        {
            MapSource.SaveLayout(MapObjects, Interactables);
        }

        #region MouseMove
        public virtual void OnMouseMove(IScreenSpacePosition screenSpacePosition)
        {
            MouseMoveOnUnit(screenSpacePosition);
            MouseMoveOnMapObject(screenSpacePosition);
        }

        private void MouseMoveOnUnit(IScreenSpacePosition screenSpacePosition)
        {
            foreach (var unit in Interactables)
            {
                if(unit is not IHoverable hoverableUnit)
                {
                    continue;
                }
                
                var pos = unit.View.ScreenSpacePosition;
                if (screenSpacePosition.X >= pos.X && screenSpacePosition.X <= pos.X + ConfigurationService2D.Dimension &&
                    screenSpacePosition.Y >= pos.Y && screenSpacePosition.Y <= pos.Y + ConfigurationService2D.Dimension)
                {
                    hoverableUnit.OnHovered();
                    continue;
                }

                if (hoverableUnit.IsHovered)
                {
                    hoverableUnit.OnHoverLost();
                }
            }
        }

        private void MouseMoveOnMapObject(IScreenSpacePosition screenSpacePosition)
        {
            foreach (var mapObject in MapObjects)
            {
                if(mapObject is not IHoverable hoverableMapObject)
                {
                    continue;
                }
                var pos = mapObject.View.ScreenSpacePosition;
                if (screenSpacePosition.X >= pos.X && screenSpacePosition.X <= pos.X + ConfigurationService2D.Dimension &&
                    screenSpacePosition.Y >= pos.Y && screenSpacePosition.Y <= pos.Y + ConfigurationService2D.Dimension)
                {
                    hoverableMapObject.OnHovered();
                    continue;
                }

                if (hoverableMapObject.IsHovered)
                {
                    hoverableMapObject.OnHoverLost();
                }
            }
        }
        #endregion

        #region LeftClick
        
        public virtual void OnMouseLeftClick(IScreenSpacePosition screenSpacePosition)
        {
            if (ClickUnit(screenSpacePosition))
            {
                return;
            }
            
            ClickMapObject(screenSpacePosition);
        }

        private bool ClickUnit(IScreenSpacePosition screenSpacePosition)
        {
            foreach (var unit in Interactables)
            {
                if(unit is not IClickable clickableUnit)
                {
                    continue;
                }
                
                var pos = unit.View.ScreenSpacePosition;
                if (screenSpacePosition.X >= pos.X && screenSpacePosition.X <= pos.X + ConfigurationService2D.Dimension &&
                    screenSpacePosition.Y >= pos.Y && screenSpacePosition.Y <= pos.Y + ConfigurationService2D.Dimension)
                {
                    if (unit.Position == SelectedObject?.Position)
                    {
                        continue;
                    }
                    
                    if (unit is IFocusable { IsTileFocused: true } focusableUnitView)
                    {
                        focusableUnitView.OnFocusLost();
                    }

                    clickableUnit.OnClicked();
                    SelectedObject = unit;
                    
                    if (unit is IFocusable focusable)
                    {
                        focusable.OnFocused();
                        return true;
                    }
                }
            }
            
            return false;
        }

        private void ClickMapObject(IScreenSpacePosition screenSpacePosition)
        {
            foreach (var mapObject in MapObjects)
            {
                if(mapObject is not IClickable clickableMapObject)
                {
                    continue;
                }
                
                var pos = mapObject.View.ScreenSpacePosition;
                if (screenSpacePosition.X >= pos.X && screenSpacePosition.X <= pos.X + ConfigurationService2D.Dimension &&
                    screenSpacePosition.Y >= pos.Y && screenSpacePosition.Y <= pos.Y + ConfigurationService2D.Dimension)
                {
                    if (mapObject == SelectedObject)
                    {
                        continue;
                    }
                    
                    if (SelectedObject is IFocusable previousFocusable)
                    {
                        previousFocusable.OnFocusLost();
                    }
                    
                    clickableMapObject.OnClicked();
                    SelectedObject = mapObject;
                    
                    if (mapObject is IFocusable focusable)
                    {
                        focusable.OnFocused();
                    }

                }
            }
        }
        
        #endregion
        
        public virtual void OnMouseRightClick()
        {
            throw new NotImplementedException();
        }

        public virtual void OnMouseLeftDoubleClick()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class AMap2D : AMap2D<IMapSource2D, IMapView2D>, IMap2D
    {
        protected AMap2D(IMapSource2D mapSource, IMapView2D view, IPositionFactory positionFactory, IConfigurationService2D configurationService)
            : base(mapSource, view, positionFactory, configurationService)
        { }
    }
}
