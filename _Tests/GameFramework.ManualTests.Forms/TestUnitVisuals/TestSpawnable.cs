using GameFramework.Board;
using GameFramework.Core.Position;
using GameFramework.Impl.Tiles.Interactable;

namespace GameFramework.ManualTests.Forms.TestUnitVisuals
{
    public class TestSpawnable : InteractableTile
    {
        public TestSpawnable(IPosition2D position, IBoardService boardService) : base(position, boardService, Color.Brown)
        { }
    }
}