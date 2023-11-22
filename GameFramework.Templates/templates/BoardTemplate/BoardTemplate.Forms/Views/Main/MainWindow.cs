using BoardTemplate.Forms.Map;
using BoardTemplate.Game.Game.Map;
using GameFramework.Core.Factories;
using GameFramework.GameFeedback;
using GameFramework.Impl.GameFeedback;
using GameFramework.Objects.Interactable;
using Microsoft.Extensions.DependencyInjection;

namespace BoardTemplate.Forms.Views.Main
{
    public sealed partial class MainWindow : Form, IMainWindow
    {
        public IMainWindowPresenter Presenter { get; }

        public MainWindow(IMainWindowPresenter presenter)
        {
            Presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
            
            const int WIDTH = 5;
            const int HEIGHT = 5;
            var mapSize = new int[HEIGHT, WIDTH];
            
            // NOTE: This is a test map, not the actual map, it has only ground types.
            var mapView = new GameMapView();
            var mapSource = new GameMapSource(Program.Application.Services, @".\test.json", mapSize, new List<IInteractableObject2D>(), WIDTH, HEIGHT);
            var map = new GameMap(mapSource, mapView, Program.Application.Services.GetRequiredService<IPositionFactory>(), Program.Application.ConfigurationService);

            Controls.Add(mapView);
            
            // NOTE: This is how you start the game.
            Program.Application.BoardService.SetActiveMap(map);
            Program.Application.Manager.StartGame(new GameplayFeedback(FeedbackLevel.Info, "Game test started"));
        }
    }
}
