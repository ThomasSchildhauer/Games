using System.Threading.Tasks;
using GamesBase.LogHelper;
using GamesBase.Interfaces;

namespace Games.Plugin.Sudoku
{
    public class StartSudokuPlugin : IGamesPlugin
    {
        private static readonly log4net.ILog log = LogHelper.GetNewLogger();
        public string Name { get; set; } = "Sudoku";

        private ISudokuPlugin _sudokuPlugin;

        public StartSudokuPlugin(ISudokuPlugin sudokuPlugin)
        {
            _sudokuPlugin = sudokuPlugin;
        }

        public void OnStartup()
        {
            log.Debug("Start: Start Games Plugin Sudoku");

            Task.Run(() => _sudokuPlugin.RunAsync());
        }
    }
}
