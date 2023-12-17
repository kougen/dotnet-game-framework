using System.Drawing;
using GameFramework.Board;
using GameFramework.Core.Position;
using GameFramework.Tiles;

namespace GameFramework.Impl.Tiles.Interactable
{
    public class HoverableInteractableTile : InteractableTile, IHoverable
    {
        public virtual bool IsHovered { get; protected set; }

        private readonly Color _initialColor;

        public HoverableInteractableTile(IPosition2D position, IBoardService boardService,
            Color color, bool isObstacle = false, bool hasBorder = false) : base(position, boardService, color,
            isObstacle, hasBorder)
        {
            _initialColor = color;
        }

        public virtual void OnHovered()
        {
            if (IsHovered)
            {
                return;
            }

            IsHovered = true;

            var prevC = View.FillColor;
            View.FillColor =
                Color.FromArgb(prevC.A, (int)(prevC.R * 1.25), (int)(prevC.G * 1.25), (int)(prevC.B * 1.25));
        }

        public virtual void OnHoverLost()
        {
            if (!IsHovered)
            {
                return;
            }

            IsHovered = false;
            View.FillColor = _initialColor;
        }
    }
}