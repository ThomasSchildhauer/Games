using Autofac;
using Base.LogHelper;
using Games.Plugin.Sudoku.Container;
using Games.Plugin.Sudoku.Database;
using Games.Plugin.Sudoku.GamePlan;
using Games.Plugin.Sudoku.GameSudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Plugin.Sudoku
{
    public class SudokuPlugin : ISudokuPlugin
    {
        private static readonly log4net.ILog log = LogHelper.GetNewLogger();
        private IDatabaseAccess _databaseAccess;
        private GamePlanView _gamePlanView;
        private IGamePlanViewModel _gamePlanViewModel;
        private IGameSudokuViewModel _gameSudokuViewModel;
        private GameSudokuView _gameSudokuView;

        public SudokuPlugin(IDatabaseAccess databaseAccess, 
            IGamePlanViewModel gamePlanViewModel,
            IGameSudokuViewModel gameSudokuViewModel)
        {
            _databaseAccess = databaseAccess;
            _gameSudokuViewModel = gameSudokuViewModel;

            CreateGameSudokuView();

            //ToDo this has to be in an other level
            //_gamePlanViewModel = gamePlanViewModel;
            //_gamePlanView = CreateGamePlanView();
            //_gamePlanView.BeginInit();


        }

        private void CreateGameSudokuView()
        {
            _gameSudokuView = new GameSudokuView()
            {
                DataContext = _gameSudokuViewModel
            };

            //ToDo I dont know if this is necessary
            _gameSudokuView.InitializeComponent();
            _gameSudokuView.Show();
        }

        private GamePlanView CreateGamePlanView()
        {
            log.Debug("CreateGamePlanView: Return GamePlanView");

            return new GamePlanView(_gamePlanViewModel)
            {
                DataContext = _gamePlanViewModel
            };
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



        }
    }
}
