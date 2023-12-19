using System.Drawing;
using GameFramework.Core.Position;
using GameFramework.Core.Position.Factories;
using GameFramework.Map.Source;
using GameFramework.Objects.Interactable;
using GameFramework.Objects.Static;
using GameFramework.Tiles.Factories;
using Microsoft.Extensions.DependencyInjection;
using ColorConverter = GameFramework.Tiles.ColorConverter;

namespace GameFramework.Impl.Map.Source
{
    public abstract class AMapSource2D : IMapSource2D
    {
        public Guid Id { get; } = Guid.NewGuid();
        public int ColumnCount { get; set; }
        public int RowCount { get; set; }
        public abstract bool Initialized { get; protected set; }
        public abstract IEnumerable<IStaticObject2D> MapObjects { get; protected set; }
        public abstract ICollection<IInteractableObject2D> Interactables { get; protected set;}
        protected readonly IPositionFactory PositionFactory;
        protected readonly ITileFactory2D TileFactory2D;
        protected readonly Color BgColor;
        
        protected AMapSource2D(IServiceProvider provider, Color bgColor)
        {
            BgColor = bgColor;
            PositionFactory = provider.GetRequiredService<IPositionFactory>();
            TileFactory2D = provider.GetRequiredService<ITileFactory2D>();
        }
        
        public abstract void SaveLayout(IEnumerable<IStaticObject2D> currentMapObjects, IEnumerable<IInteractableObject2D> currentInteractables);
        
        protected virtual Func<int, IPosition2D, IStaticObject2D> GetConverter()
        {
            return (value, position) => TileFactory2D.CreateHoverableStaticObject2D(position, ColorConverter.ConvertTileIdToColor(value));
        }
        
        protected virtual Func<int, int, int, IInteractableObject2D> GetInteractableConverter()
        {
            return (colorId, x, y) => TileFactory2D.CreateInteractableTile2D(PositionFactory.CreatePosition(x, y), ColorConverter.ConvertTileIdToColor(colorId));
        }
    }
}
