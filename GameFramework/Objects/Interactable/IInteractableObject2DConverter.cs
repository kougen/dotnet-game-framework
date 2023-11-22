using GameFramework.Core.Position;

namespace GameFramework.Objects.Interactable
{
    public interface IInteractableObject2DConverter
    {
        IInteractableObject2D FromEnum<T>(T tileType, IPosition2D position) where T : Enum;
    }
}
