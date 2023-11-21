namespace GameFramework.Tiles
{
    public interface IHoverable
    {
        bool IsHovered { get; }
        void OnHovered();
        void OnHoverLost();
    }
}
