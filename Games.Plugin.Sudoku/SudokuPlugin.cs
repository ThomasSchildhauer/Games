using GamesBase.LogHelper;
using Games.Plugin.Sudoku.Database;
using Games.Plugin.Sudoku.GamePlan;
using Games.Plugin.Sudoku.GameSudoku;
using Games.Plugin.Sudoku.GameSudoku.NewGame;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Games.Plugin.Sudoku
{
    public class SudokuPlugin : ISudokuPlugin
    {
        private static readonly log4net.ILog log = LogHelper.GetNewLogger();
        private IDatabaseAccess _databaseAccess;
        private GameSudokuView _gameSudokuView;

        //Constructor
        public SudokuPlugin(
            IDatabaseAccess databaseAccess, 
            GameSudokuView gameSudokuView)
        {
            _databaseAccess = databaseAccess;
            _gameSudokuView = gameSudokuView;

            // Events
            //_gameSudokuViewModel.OpenNewGame += OpenNewGameView;
            //OpenGameSudokuView();
        }

        private void OpenGameSudokuView()
        {
            _gameSudokuView.InitializeComponent();
            _gameSudokuView.Show();
        }

        public async Task RunAsync()
        {
            log.Debug("RunAsync: Task.Run() App");
            _databaseAccess.LoadingDone += ProceedAfterLoading;
            OpenGameSudokuView();
            await _databaseAccess.LoadDatabaseAsync();
        }

        public void ProceedAfterLoading(object sende, EventArgs e)
        {
            //ToDo here it goes on...
            //_newGameViewModel.SetDifficulty += ProceedAfterDifficultyChosen;
        }

        public void ProceedAfterDifficultyChosen(object sender, EventArgs e)
        {
            //SystemCommands.CloseWindow(_newGameView);
        }
    }
}
