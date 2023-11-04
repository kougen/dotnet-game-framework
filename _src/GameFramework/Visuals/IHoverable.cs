namespace GameFramework.Visuals
{
    public interface IHoverable
    {
        bool IsHovered { get; }
        void OnHovered();
        void OnHoverLost();
    }
}
