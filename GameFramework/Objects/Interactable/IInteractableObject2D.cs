namespace GameFramework.Objects.Interactable
{
    public interface IInteractableObject2D : IObject2D, IDisposable
    {
        Guid Id { get; }
        void Step(IObject2D staticObject);
        void Delete();
    }
}
