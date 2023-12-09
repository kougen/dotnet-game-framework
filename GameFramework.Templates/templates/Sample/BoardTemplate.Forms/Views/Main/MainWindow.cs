using BoardTemplate.Forms.Map;
using BoardTemplate.Game;

namespace BoardTemplate.Forms.Views.Main
{
    public sealed partial class MainWindow : Form, IMainWindow
    {
        public IMainWindowPresenter Presenter { get; }

        public MainWindow(IMainWindowPresenter presenter)
        {
            Presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
            var mapControl = new GameMapView();
            var gameplay = new Gameplay(Program.Application, mapControl);
            
            Controls.Add(mapControl);
        }
    }
}
