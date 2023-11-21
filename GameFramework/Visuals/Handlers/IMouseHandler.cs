using GameFramework.Core.Position;

namespace GameFramework.Visuals.Handlers
{
    public interface IMouseHandler
    {
        void OnMouseMove(IScreenSpacePosition screenSpacePosition);
        void OnMouseLeftClick(IScreenSpacePosition screenSpacePosition);
        void OnMouseRightClick();
        void OnMouseLeftDoubleClick();
    }
}
