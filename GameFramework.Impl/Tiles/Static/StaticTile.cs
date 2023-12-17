using System.Drawing;
using GameFramework.Board;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Objects.Interactable;
using GameFramework.Objects.Static;
using GameFramework.Visuals.Factories;
using GameFramework.Visuals.Tiles;

namespace GameFramework.Impl.Tiles.Static
{
    public class StaticTile : IStaticObject2D
    {
        public IObjectView2D View { get; }
        public IPosition2D Position { get; }
        public bool IsObstacle { get; }

        public virtual void SteppedOn(IInteractableObject2D interactableObject2D)
        {
            
        }

        protected IConfigurationService2D ConfigurationService;
        protected ITileViewFactory2D TileViewFactory2D;
        
        public StaticTile(IPosition2D position, IBoardService boardService, Color fillColor, bool isObstacle = false, bool hasBorder = false)
        {
            Position = position ?? throw new ArgumentNullException(nameof(position));
            ConfigurationService = boardService.ConfigurationService2D;
            IsObstacle = isObstacle;
            TileViewFactory2D = boardService.TileViewFactory2D;
            View = TileViewFactory2D.CreateTileView2D(position, fillColor, hasBorder);
        }
    }
}
