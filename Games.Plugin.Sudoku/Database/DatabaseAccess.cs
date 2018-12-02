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
            return ReadDatabaseAsync();
        }

        public void AddToDatabase(IGamePlanViewModel gamePlanModel)
        {
            _database.GamePlans.Add(gamePlanModel);
        }

        private async Task<List<IGamePlanViewModel>> ReadDatabaseAsync()
        {
            List<Task<IGamePlanViewModel>> tasks = new List<Task<IGamePlanViewModel>>();
            foreach(IGamePlanViewModel item in _database.GamePlans)
            {
                tasks.Add(Task.Run(()=>item));
            }

            var _gamePlanViewModels = await Task.WhenAll(tasks);

            return _gamePlanViewModels.ToList();
        }
    }
}
