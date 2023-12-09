using System.Drawing;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.UI.WPF.Tiles.Interactable;

namespace GameFramework.ManualTests.Desktop.WPF.GameCanvas.TestUnitVisuals
{
    public class TestInteractableView : AInteractableTileView
    {
        public TestInteractableView(IPosition2D position, IConfigurationService2D configurationService) : base(position, configurationService, Color.Blue, true)
        { }
    }
}
