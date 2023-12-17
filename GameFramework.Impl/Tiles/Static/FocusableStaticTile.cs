using System.Drawing;
using GameFramework.Board;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Visuals;

namespace GameFramework.Impl.Tiles.Static
{
    public class FocusableStaticTile : StaticTile, IFocusable
    {
        public bool IsTileFocused { get; protected set; }

        public FocusableStaticTile(IPosition2D position, IBoardService boardService, Color fillColor, bool isObstacle = false, bool hasBorder = false) : base(position, boardService, fillColor, isObstacle, hasBorder)
        { }
        
        public virtual void OnFocused()
        {
            IsTileFocused = true;
        }
        
        public virtual void OnFocusLost()
        {
            IsTileFocused = false;
        }

        public bool IsClickEnabled { get; set; }
        
        public void OnClicked()
        {
            
        }
    }
}
