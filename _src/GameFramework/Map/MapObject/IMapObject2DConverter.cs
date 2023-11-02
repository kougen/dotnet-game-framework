using GameFramework.Core;

namespace GameFramework.Map.MapObject
{
    public interface IMapObject2DConverter
    {
        IMapObject2D FromEnum<T>(T tileType, IPosition2D position) where T : Enum;
        IMapObject2D FromInt(int type, IPosition2D position);
    }
}
