using GameFramework.Visuals.Tiles;

namespace GameFramework.Objects.Interactable
{
    public interface IInteractableObject2D : IObject2D
    {
        Guid Id { get; }
        void Step(IObject2D staticObject);
        void Delete();
    }
}
