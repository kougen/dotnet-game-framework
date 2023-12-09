using GameFramework.Board;
using GameFramework.Configuration;
using GameFramework.Core;
using GameFramework.Core.Factories;
using GameFramework.Impl.Configuration;
using GameFramework.Impl.Core.Position.Factories;
using GameFramework.Impl.Tiles;
using GameFramework.Impl.Tiles.Factories;
using GameFramework.Manager;
using GameFramework.Objects.Static;
using GameFramework.Tiles.Factories;
using Implementation.Module;
using Infrastructure.Application;
using Infrastructure.Configuration.Factories;
using Infrastructure.Module;
using Microsoft.Extensions.DependencyInjection;

namespace GameFramework.Impl.Core
{
    public class GameFrameworkCore : AModule, ICancellableModule, IBaseModule
    {
        public CancellationTokenSource Source { get; }
        
        public GameFrameworkCore(IServiceCollection collection, CancellationTokenSource source) : base(collection)
        {
            Source = source ?? throw new ArgumentNullException(nameof(source));
        }

        public override IModule RegisterServices(IServiceCollection collection)
        {
            collection.AddSingleton<IConfigurationService2D, ConfigurationService2D>(p =>
            {
                var appSettings = p.GetRequiredService<IApplicationSettings>();
                var confQueryFactory = p.GetRequiredService<IConfigurationQueryFactory>();
                return new ConfigurationService2D(appSettings, confQueryFactory);
            });

            collection.AddSingleton<IPositionFactory, PositionFactory>();
            collection.AddSingleton<IGameManager, GameManager>();
            collection.AddSingleton<IBoardService, BoardService>();
            collection.AddSingleton<IStaticObject2DConverter, DefaultStaticTileConverter>();
            collection.AddSingleton<ITileFactory2D, DefaultTileFactory>();
            
            return this;
        }
    }
}
