using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.UI.Maui.Tiles.Interactable;

namespace GameFramework.Maui.Tests.TestUnitVisuals
{
    public class TestInteractableView : AInteractableTileView
    {
        public TestInteractableView(IPosition2D position, IConfigurationService2D configurationService) : base(position, configurationService, Colors.Blue, true)
        { }
    }
}
