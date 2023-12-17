using System.Drawing;
using GameFramework.Board;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Visuals;

namespace GameFramework.Impl.Tiles.Interactable
{
    public class FocusableInteractableTile : InteractableTile, IFocusable
    {
        public bool IsTileFocused { get; protected set; }
        
        public FocusableInteractableTile(IPosition2D position, IBoardService boardService,
            Color color, bool isObstacle = false, bool hasBorder = false) : base(position, boardService, color, isObstacle, hasBorder)
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
