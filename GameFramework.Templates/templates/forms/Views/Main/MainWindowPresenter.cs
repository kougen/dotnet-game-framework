using GameFramework.Board;
using GameFramework.Forms.Game.Map;
using GameFramework.Forms.Views.Main;

namespace GameFramework.Forms.Views.Main
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
            var map = _boardService.GetActiveMap<IGameMap>();
            if (map == null)
            {
                return;
            }
            
            map.SaveProgress();
        }
    }
}
