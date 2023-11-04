using GameFramework.Core;

namespace GameFramework.Visuals
{
    public interface IMouseHandler
    {
        void OnMouseMove(IScreenSpacePosition screenSpacePosition);
        void OnMouseLeftClick(IScreenSpacePosition screenSpacePosition);
        void OnMouseRightClick();
        void OnMouseLeftDoubleClick();
    }
}
