using GameFramework.Forms.Game.Map;
using GameFramework.Forms.Views.Main;
using GameFramework.Impl.Core;
using GameFramework.Map.MapObject;
using GameFramework.UI.Forms.Core;
using Implementation.Module;
using Microsoft.Extensions.DependencyInjection;

namespace GameFramework.Forms
{
    public class ProgramCore : ProgramCore2D
    {
        protected override IServiceProvider LoadModules(ServiceCollection collection)
        {
            // NOTE: Register your modules here
            var source = new CancellationTokenSource();
            var core = new CoreModule(collection, source);
            
            // NOTE: Change this to your namespace
            core.RegisterServices("joshika39.MyGame");
            core.RegisterOtherServices(new GameFrameworkCore(collection, source));
            
            // NOTE: Register your services here
            collection.AddSingleton<IMapObject2DConverter, DefaultMapObjectConverter>();
            collection.AddScoped<IMainWindowPresenter, MainWindowPresenter>();
            collection.AddSingleton<IMainWindow>(p =>
            {
                var presenter = p.GetRequiredService<IMainWindowPresenter>();
                return new MainWindow(presenter);
            });
            
            return collection.BuildServiceProvider();
        }
    }
}
