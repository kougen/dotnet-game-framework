using System;
using System.Collections.Generic;
using System.Drawing;
using GameFramework.Impl.Map.Source;
using GameFramework.Objects.Interactable;

namespace GameFramework.ManualTests.Desktop.WPF.GameCanvas
{
    public class TestMapSource : JsonMapSource2D
    {
        public TestMapSource(string filePath, IServiceProvider provider, int col, int row, Color? bgColor = null, ICollection<IInteractableObject2D>? interactables = null) : base(filePath, provider, col, row, bgColor, interactables)
        { }
    }
}
