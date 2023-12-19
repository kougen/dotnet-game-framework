using BoardTemplate.Game.Map;
using BoardTemplate.Game.Visuals;
using GameFramework.Application;
using GameFramework.Core.Position.Factories;
using GameFramework.GameFeedback;
using GameFramework.Impl.GameFeedback;
using GameFramework.Manager;
using GameFramework.Objects.Interactable;
using Microsoft.Extensions.DependencyInjection;

namespace BoardTemplate.Game;

public class Gameplay
{
    private static IApplication2D? _application2D;

    public static IApplication2D? Application2D
    {
        get => _application2D;
        set => _application2D ??= value;
    }
    
    public void OpenMap(string mapFileName, IGameMapView mapView2D)
    {
        if (Application2D is null)
        {
            return;
        }
        
        const int WIDTH = 5;
        const int HEIGHT = 5;

        var mapSource = new GameMapSource(mapFileName, Application2D.Services, WIDTH, HEIGHT);
        var map = new GameMap(mapSource, mapView2D, Application2D.Services.GetRequiredService<IPositionFactory>(),
            Application2D.ConfigurationService);

        // NOTE: This is how you start the game.
        Application2D.BoardService.SetActiveMap(map);
        Application2D.Manager.StartGame(new GameplayFeedback(FeedbackLevel.Info, "Game test started"));
    }

    public void OpenMap(IGameMapView mapView2D)
    {
        OpenMap(Path.Join(".", "temp.json"), mapView2D);
    }
    
    public void PauseGame()
    {
        if (Application2D is null)
        {
            return;
        }

        if (Application2D.Manager.State == GameState.Paused)
        {
            Application2D.Manager.ResumeGame();
        }
        else
        {
            Application2D.Manager.PauseGame();
        }
    }
    
    public void HandleKeyPress(char keyChar)
    {
        if (Application2D is null)
        {
            return;
        }

        var map = Application2D.BoardService.GetActiveMap<GameMap>();

        switch (keyChar)
        {
            case 'd':
                
                break;
            case 'a':
                
                break;
            case 'w':
                
                break;
            case 's':
                
                break;
            case 'p':
                PauseGame();
                break;
            case 'r':
                Application2D.Manager.ResetGame();
                break;
        }
    }
    
    public void SaveGame()
    {
        var map = Application2D?.BoardService.GetActiveMap<GameMap>();
        
        // NOTE: This is how you save the map.
        map?.SaveProgress();
    }

}