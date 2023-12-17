namespace GameFramework.Tiles
{
    public interface IClickable
    {
        bool IsClickEnabled { get; set; }
        void OnClicked();
    }
}
