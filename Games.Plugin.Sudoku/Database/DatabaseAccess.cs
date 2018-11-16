using Games.Plugin.Sudoku.GamePlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games.Plugin.Sudoku.Database;

namespace Games.Plugin.Sudoku.Database
{
    public class DatabaseAccess : IDatabaseAccess
    {
        private IDatabase _database;
        public DatabaseAccess(IDatabase database)
        {
            _database = database;
        }

        public List<IGamePlanViewModel> ReadDatabase()
        {
            return _database.GamePlan;
        }

        public void AddToDatabase(IGamePlanViewModel gamePlanModel)
        {
            _database.GamePlan.Add(gamePlanModel);
        }
    }
}
