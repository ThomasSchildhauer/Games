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
        public SudokuPlugin(IDatabaseAccess databaseAccess, List<IGamePlanViewModel> gamePlanViewModels)
        {
            _databaseAccess = databaseAccess;
            _gamePlanView = CreateGamePlanView();
        }

        private GamePlanView CreateGamePlanView()
        {
            return new GamePlanView();
        }

        public void Run()
        {
            _gamePlanViewModels = _databaseAccess.ReadDatabase();
        }
    }
}
