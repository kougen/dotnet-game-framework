namespace GameFramework.Core.Factories
{
    public interface IPositionFactory
    {
        IPosition2D CreatePosition(int x, int y);
        IPosition3D CreatePosition(int x, int y, int z);
    }
}
