using GameFramework.Tiles;

namespace GameFramework.Visuals
{
    public interface IFocusable : IClickable
    {
        bool IsTileFocused { get; }
        void OnFocused();
        void OnFocusLost();
    }
}
