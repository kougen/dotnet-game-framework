namespace GameFramework.Visuals
{
    public interface IFocusable : IClickable
    {
        void OnFocused();
        void OnFocusLost();
    }
}
