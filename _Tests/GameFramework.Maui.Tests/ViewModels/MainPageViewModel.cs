using GameFramework.Core.Factories;
using GameFramework.GameFeedback;
using GameFramework.Impl.Core.Position;
using GameFramework.Impl.GameFeedback;
using GameFramework.Impl.Map.Source;
using GameFramework.Maui.Tests.TestUnitVisuals;
using GameFramework.Objects.Interactable;
using GameFramework.UI.Maui.Core;
using GameFramework.UI.Maui.Map;
using Color = System.Drawing.Color;

namespace GameFramework.Maui.Tests.ViewModels
{
    public class MainPageViewModel
    {
        public MauiMapControl MapControl { get; set; }

        public MainPageViewModel()
        {
            const int WIDTH = 5;
            const int HEIGHT = 5;
            var mapSize = new int[HEIGHT, WIDTH];

            var unitView = GameApp2D.Current.BoardService.TileViewFactory2D
                .CreateInteractableTileView2D(new Position2D(1, 1), Color.Blue);
            var unit = new TestInteractableObject(unitView, new Position2D(1, 1));

            // NOTE: This is a test map, not the actual map, it has only ground types.
            MapControl = new MauiMapControl();
            var mapSource = new JsonMapSource2D(GameApp2D.Current.Services, @".\test.json", mapSize,
                new List<IInteractableObject2D>(), WIDTH, HEIGHT);
            var map = new GameMap(mapSource, MapControl,
                GameApp2D.Current.Services.GetRequiredService<IPositionFactory>(),
                GameApp2D.Current.ConfigurationService);

            // NOTE: This is how you start the game.
            GameApp2D.Current.BoardService.SetActiveMap(map);
            GameApp2D.Current.Manager.StartGame(new GameplayFeedback(FeedbackLevel.Info, "Game test started"));

            map.Interactables.Add(unit);
            
            Task.Run(async () =>
            {
                for (var i = 0; i < 6; i++)
                {
                    await GameApp2D.Current.Manager.Timer.WaitAsync(1000, unit);
                }
            });
        }
    }
}