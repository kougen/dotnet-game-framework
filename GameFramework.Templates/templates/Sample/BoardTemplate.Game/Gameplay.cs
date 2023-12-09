using BoardTemplate.Game.Game.Map;
using GameFramework.Application;
using GameFramework.Core.Factories;
using GameFramework.GameFeedback;
using GameFramework.Impl.GameFeedback;
using GameFramework.Objects.Interactable;
using Microsoft.Extensions.DependencyInjection;

namespace BoardTemplate.Game;

public class Gameplay
{
    private readonly IApplication2D _application2D;
    private readonly IGameMapView _gameMapView;

    public Gameplay(IApplication2D application2D, IGameMapView gameMapView)
    {
        _application2D = application2D ?? throw new ArgumentNullException(nameof(application2D));
        _gameMapView = gameMapView ?? throw new ArgumentNullException(nameof(gameMapView));

        const int WIDTH = 5;
        const int HEIGHT = 5;
        var mapSize = new int[HEIGHT, WIDTH];
        
        var mapSource = new GameMapSource(_application2D.Services, @".\test.json", mapSize, new List<IInteractableObject2D>(), WIDTH, HEIGHT);
        var map = new GameMap(mapSource, gameMapView, _application2D.Services.GetRequiredService<IPositionFactory>(), _application2D.ConfigurationService);

        // NOTE: This is how you start the game.
        _application2D.BoardService.SetActiveMap(map);
        _application2D.Manager.StartGame(new GameplayFeedback(FeedbackLevel.Info, "Game test started"));
            
        // NOTE: This is how you save the map.
        map.SaveProgress();
    }
}