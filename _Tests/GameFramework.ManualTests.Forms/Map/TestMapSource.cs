using GameFramework.Impl.Map.Source;
using GameFramework.Objects.Interactable;

namespace GameFramework.ManualTests.Forms.Map
{
    public class TestMapSource : JsonMapSource2D
    {
        public TestMapSource(string filePath, IServiceProvider provider, int col, int row, Color? bgColor = null, ICollection<IInteractableObject2D>? interactables = null, bool bypass = false) : base(filePath, provider, col, row, bgColor, interactables, bypass)
        { }
    }
}
