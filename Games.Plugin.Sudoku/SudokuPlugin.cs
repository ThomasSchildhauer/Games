using Autofac;
using Games.Plugin.Sudoku.Container;
using Games.Plugin.Sudoku.Database;
using Games.Plugin.Sudoku.GamePlan;
using Games.Plugin.Sudoku.GameSudoku;
using Games.Plugin.Sudoku.GameSudoku.NewGame;
using GamesUI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Games.Plugin.Sudoku
{
    public class SudokuPlugin : ISudokuPlugin
    {
        private static readonly log4net.ILog log = LogHelper.GetNewLogger();
        private IDatabaseAccess _databaseAccess;
        private IGameSudokuViewModel _gameSudokuViewModel;
        private GameSudokuView _gameSudokuView;
        private INewGameViewModel _newGameViewModel;
        private NewGameView _newGameView;
        private IGamePlanViewModel _gamePlanViewModel;
        private GamePlanView _gamePlanView;

        //Constructor
        public SudokuPlugin(
            IDatabaseAccess databaseAccess, 
            IGameSudokuViewModel gameSudokuViewModel,
            GameSudokuView gameSudokuView,
            INewGameViewModel newGameViewModel,
            NewGameView newGameView,
            IGamePlanViewModel gamePlanViewModel,
            GamePlanView gamePlanView)
        {
            _databaseAccess = databaseAccess;
            _gameSudokuViewModel = gameSudokuViewModel;
            _gameSudokuView = gameSudokuView;
            _newGameViewModel = newGameViewModel;
            _newGameView = newGameView;
            _gamePlanViewModel = gamePlanViewModel;
            _gamePlanView = gamePlanView;

            // View DataContext
            _gameSudokuView.DataContext = _gameSudokuViewModel;
            _newGameView.DataContext = _newGameViewModel;
            _gamePlanView.DataContext = _gamePlanViewModel;

            // Events
            _gameSudokuViewModel.OpenNewGame += OpenNewGameView;
            OpenGameSudokuView();
        }

        private void OpenGameSudokuView()
        {
            _gameSudokuView.InitializeComponent();
            _gameSudokuView.Show();
        }

        private void OpenGamePlanView()
        {
            _gamePlanView.InitializeComponent();
            _gamePlanViewModel.UcIsVisible = true;
        }

        private void OpenNewGameView(object sender, EventArgs e)
        {
            _newGameView.InitializeComponent();
            _newGameView.Show();
        }

        public async Task RunAsync()
        {
            log.Debug("RunAsync: Task.Run() App");
            _databaseAccess.LoadingDone += ProceedAfterLoading;
            await _databaseAccess.LoadDatabaseAsync();
        }

        public void ProceedAfterLoading(object sende, EventArgs e)
        {
            //ToDo here it goes on...
            _newGameViewModel.SetDifficulty += ProceedAfterDifficultyChosen;
        }

        public void ProceedAfterDifficultyChosen(object sender, EventArgs e)
        {
            SystemCommands.CloseWindow(_newGameView);
        }
    }
}
