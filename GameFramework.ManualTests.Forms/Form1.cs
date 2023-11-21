using GameFramework.Core.Factories;
using GameFramework.GameFeedback;
using GameFramework.Impl.GameFeedback;
using GameFramework.Impl.Map.Source;
using GameFramework.ManualTests.Forms.Map;
using GameFramework.Objects;
using Microsoft.Extensions.DependencyInjection;

namespace GameFramework.ManualTests.Forms
{
    public partial class Form1 : Form
    {
        private readonly TestMap _map;
    
        public Form1()
        {
            InitializeComponent();
            var data = new int[5, 7];
            var mapView = new TestMapView();
            var mapSource = new JsonMapSource2D(Program.Application.Services, @".\test.json", data, new List<IInteractableObject2D>(), 7, 5);
        
            _map = new TestMap(mapSource, mapView, Program.Application.Services.GetRequiredService<IPositionFactory>(), Program.Application.ConfigurationService);
            if (_map.View is Control control)
            {
                Controls.Add(control);
            }
        
            Program.Application.Manager.StartGame(new GameplayFeedback(FeedbackLevel.Info, "Game test started"));
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }
    }
}
