using System.Drawing;
using GameFramework.Board;
using GameFramework.Core.Position;
using GameFramework.Tiles;

namespace GameFramework.Impl.Tiles.Static
{
    public class ClickableStaticTile : StaticTile, IClickable
    {
        public bool IsClickEnabled { get; set; }

        public ClickableStaticTile(IPosition2D position, IBoardService boardService, Color fillColor, bool isObstacle = false, bool hasBorder = false) : base(position, boardService, fillColor, isObstacle, hasBorder)
        {
        }
        
        public virtual void OnClicked()
        {
            if(!IsClickEnabled)
            {
                return;
            }
        }
    }
}
