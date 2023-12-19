using BoardTemplate.Game.Map;
using GameFramework.Board;

namespace BoardTemplate.Forms.Views.Main
{
    internal class MainWindowPresenter : IMainWindowPresenter
    {
        private readonly IBoardService _boardService;

        public MainWindowPresenter(IBoardService boardService)
        {
            _boardService = boardService ?? throw new ArgumentNullException(nameof(boardService));
        }
        
        public void SaveMap()
        {
            var map = _boardService.GetActiveMap<GameMap>();
            map?.SaveProgress();
        }
    }
}
