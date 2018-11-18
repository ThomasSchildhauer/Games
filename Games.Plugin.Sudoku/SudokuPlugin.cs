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
        private IDatabaseAccess _databaseAccess;
        private List<IGamePlanViewModel> _gamePlanViewModels;
        private GamePlanView _gamePlanView;
        private IGamePlanViewModel _gamePlanViewModel;
        public SudokuPlugin(IDatabaseAccess databaseAccess, List<IGamePlanViewModel> gamePlanViewModels, IGamePlanViewModel gamePlanViewModel)
        {
            _databaseAccess = databaseAccess;
            _gamePlanViewModel = gamePlanViewModel;
            _gamePlanView = CreateGamePlanView();
        }

        private GamePlanView CreateGamePlanView()
        {
            return new GamePlanView(_gamePlanViewModel);
        }

        public void Run()
        {
            _gamePlanViewModels = _databaseAccess.ReadDatabase();
            _gamePlanViewModel = _gamePlanViewModels.First();

        }
    }
}
