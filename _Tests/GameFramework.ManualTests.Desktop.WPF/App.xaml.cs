using System;
using System.Threading;
using GameFramework.Impl.Core;
using GameFramework.Map.MapObject;
using GameFramework.UI.WPF.Core;
using GameFramework.UI.WPF.Map;
using Implementation.Module;
using Microsoft.Extensions.DependencyInjection;

namespace GameFramework.ManualTests.Desktop.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App2D : GameApp2D
    {
        protected override IServiceProvider LoadModules(ServiceCollection collection)
        {
            new CoreModule().LoadModules(collection, "game-framework-wpf-tests");
            new GameModule().LoadModules(collection, new CancellationTokenSource());
            collection.AddSingleton<IMapObject2DConverter, DefaultMapObjectConverter>();
            return collection.BuildServiceProvider();
        }
    }
}
