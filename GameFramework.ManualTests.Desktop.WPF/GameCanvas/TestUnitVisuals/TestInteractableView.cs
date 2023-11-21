using System.Windows.Media;
using GameFramework.Configuration;
using GameFramework.Core.Position;
using GameFramework.Objects;
using GameFramework.UI.WPF.Tiles;

namespace GameFramework.ManualTests.Desktop.WPF.GameCanvas.TestUnitVisuals
{
    public class TestInteractableView : AInteractableTileView
    {
        public TestInteractableView(IPosition2D position, IConfigurationService2D configurationService) : base(position, configurationService, Colors.Blue, true)
        { }
    }
}
