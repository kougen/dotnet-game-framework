using System;
using System.Collections.Generic;
using GameFramework.Entities;
using GameFramework.Impl.Map.Source;
using GameFramework.Map;

namespace GameFramework.ManualTests.Desktop.WPF.GameCanvas
{
    public class TestMapSource : JsonMapSource2D, IMapSource2D
    {
        
        public TestMapSource(IServiceProvider provider, string filePath, int[,] data, ICollection<IUnit2D> units, int col, int row) : base(provider, filePath, data, units, col, row)
        { }
        public TestMapSource(IServiceProvider provider, string filePath) : base(provider, filePath)
        { }
    }
}
