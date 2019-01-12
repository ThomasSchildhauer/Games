using Base.LogHelper;
using Games.Plugin.Sudoku.Database;
using Games.Plugin.Sudoku.GamePlan;
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
        //private List<IGamePlanViewModel> _gamePlanViewModels;
        private GamePlanView _gamePlanView;
        private IGamePlanViewModel _gamePlanViewModel;

        public SudokuPlugin(IDatabaseAccess databaseAccess, IGamePlanViewModel gamePlanViewModel)
        {
            _databaseAccess = databaseAccess;

            _gamePlanViewModel = gamePlanViewModel;

            _gamePlanView = CreateGamePlanView();
        }

        private GamePlanView CreateGamePlanView()
        {
            log.Debug("CreateGamePlanView: Return GamePlanView");

            return new GamePlanView(_gamePlanViewModel);
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
