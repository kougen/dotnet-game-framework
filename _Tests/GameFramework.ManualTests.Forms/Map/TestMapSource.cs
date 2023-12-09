using GameFramework.Impl.Map.Source;
using GameFramework.Objects.Interactable;

namespace GameFramework.ManualTests.Forms.Map
{
    public class TestMapSource : JsonMapSource2D
    {
        
        public TestMapSource(IServiceProvider provider, string filePath, int[,] data, ICollection<IInteractableObject2D> units, int col, int row) : base(provider, filePath, data, units, col, row)
        { }
        public TestMapSource(IServiceProvider provider, string filePath) : base(provider, filePath)
        { }
    }
}
