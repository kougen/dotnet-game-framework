using System.Diagnostics;
using System.Drawing;
using GameFramework.Board;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Tiles;

namespace GameFramework.Impl.Tiles.Interactable
{
    public class ClickableInteractableTile : InteractableTile, IClickable
    {
        public bool IsClickEnabled { get; set; }
        
        public ClickableInteractableTile(IPosition2D position, IBoardService boardService, Color color, bool isObstacle = false, bool hasBorder = false) : base(position, boardService, color, isObstacle, hasBorder)
        { }
        
        public virtual void OnClicked()
        {
            if(!IsClickEnabled)
            {
                return;
            }
            
            Debug.WriteLine("Clicked");
        }
    }
}
