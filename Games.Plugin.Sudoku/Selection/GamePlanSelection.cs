using GamesBase.LogHelper;
using Games.Plugin.Sudoku.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Plugin.Sudoku.Selection
{
    public class GamePlanSelection
    {
        private static readonly log4net.ILog log = LogHelper.GetNewLogger();

        private IDatabaseAccess _databaseAccess;

        GamePlanSelection(IDatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
            _databaseAccess.LoadingDone += FetchGamePlanViewModels;
        }

        private void FetchGamePlanViewModels(object s, EventArgs a)
        {
            log.Debug("FetchGamePlanViewModels: Has to be Coded first...");
        }
    }
}
