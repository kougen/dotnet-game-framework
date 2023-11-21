using GameFramework.Core.Position;

namespace GameFramework.Objects
{
    public interface IMapObject2DConverter
    {
        IStaticObject2D FromEnum<T>(T tileType, IPosition2D position) where T : Enum;
        IStaticObject2D FromInt(int type, IPosition2D position);
    }
}
