using GameFramework.Impl.Core;
using GameFramework.Objects;
using GameFramework.UI.Forms.Core;
using GameFramework.UI.Forms.Map;
using Implementation.Module;
using Microsoft.Extensions.DependencyInjection;

namespace GameFramework.ManualTests.Forms
{
    internal class TestProgramCore : ProgramCore2D
    {
        protected override IServiceProvider LoadModules(ServiceCollection collection)
        {
            var source = new CancellationTokenSource();
            var core = new CoreModule(collection, source);
            core.RegisterServices("gf-manual-tests");
            core.RegisterOtherServices(new GameFrameworkCore(collection, source));
            
            return collection.AddSingleton<IMapObject2DConverter, FormsMapObjectConverter>().BuildServiceProvider();
        }
    }
}
