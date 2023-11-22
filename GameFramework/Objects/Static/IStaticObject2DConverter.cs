using GameFramework.Core.Position;

namespace GameFramework.Objects.Static
{
    public interface IStaticObject2DConverter
    {
        IStaticObject2D FromEnum<T>(T tileType, IPosition2D position) where T : Enum;
    }
}
