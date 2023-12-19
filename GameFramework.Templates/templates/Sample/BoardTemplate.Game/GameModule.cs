using Implementation.Module;
using Infrastructure.Module;
using Microsoft.Extensions.DependencyInjection;

namespace BoardTemplate.Game;

public class GameModule : AModule, IBaseModule
{
    public GameModule(IServiceCollection collection) : base(collection)
    { }

    public override IModule RegisterServices(IServiceCollection collection)
    {
        return this;
    }
}