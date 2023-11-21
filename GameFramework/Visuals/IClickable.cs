namespace GameFramework.Visuals
{
    public interface IClickable
    {
        bool IsClickEnabled { get; set; }
        void OnClicked();
    }
}
