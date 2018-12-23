using Games.Plugin.Sudoku.GamePlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games.Plugin.Sudoku.Database;
using Games.Plugin.Sudoku.Events;

namespace Games.Plugin.Sudoku.Database
{
    public class DatabaseAccess : OnPropertyCange, IDatabaseAccess
    {
        public event EventHandler LoadingDone;
        private IDatabase _database;
        private List<IGamePlanViewModel> _gamePlans;
        public List<IGamePlanViewModel> GamePlans
        {
            get => _gamePlans;
            private set => ChangedProperty(value, ref _gamePlans);
        }

        public DatabaseAccess(IDatabase database)
        {
            _database = database;
        }

        public async Task LoadDatabaseAsync()
        {
            GamePlans = await LoopThroughDatabaseParallelAsync();
            if (LoadingDone == null)
            {
                LoadingDone(this, EventArgs.Empty);
            }
        }

        public async Task AddToDatabaseAsync(IGamePlanViewModel gamePlanModel)
        {
            await Task.Run(() => _database.GamePlans.Add(gamePlanModel));
            GamePlans.Add(gamePlanModel);
        }


        //still here for testing purposes
        private async Task<List<IGamePlanViewModel>> LoopThroughDatabaseAsync()
        {
            List<Task<IGamePlanViewModel>> tasks = new List<Task<IGamePlanViewModel>>();
            foreach (IGamePlanViewModel item in _database.GamePlans)
            {
                tasks.Add(Task.Run(() => item));
            }

            var _gamePlanViewModels = await Task.WhenAll(tasks);

            return _gamePlanViewModels.ToList();
        }

        private async Task<List<IGamePlanViewModel>> LoopThroughDatabaseParallelAsync()
        {
            List<IGamePlanViewModel> gamePlans = new List<IGamePlanViewModel>();

            Parallel.ForEach<IGamePlanViewModel>(gamePlans, (item) => gamePlans.Add(item));

            //ToDo await is still missing here!
            return gamePlans.ToList();
        }

        public async Task ShowProgress()
        {
            //ToDo Implement This
        }

        public void CancelLoading()
        {
            //ToDo Implement This
        }
    }
}
