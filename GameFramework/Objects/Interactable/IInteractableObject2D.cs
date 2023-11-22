using GameFramework.Visuals.Views;

namespace GameFramework.Objects.Interactable
{
    public interface IInteractableObject2D : IObject2D, IDisposable
    {
        Guid Id { get; }
        IMovingObjectView View { get; }
        void Step(IObject2D staticObject);
        void Delete();
    }
}
