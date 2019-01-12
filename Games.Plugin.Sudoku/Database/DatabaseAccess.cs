using Games.Plugin.Sudoku.GamePlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games.Plugin.Sudoku.Database;
using Games.Plugin.Sudoku.Events;
using Base.LogHelper;

namespace Games.Plugin.Sudoku.Database
{
    public class DatabaseAccess : OnPropertyCange, IDatabaseAccess
    {
        private static readonly log4net.ILog log = LogHelper.GetNewLogger();

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
            log.Debug("LoadDatabaseAsync: ");

            GamePlans = await LoopThroughDatabaseParallelAsync();

            //ToDo something throws a System.NullReferenceException
            //if (LoadingDone == null)
            //{
            //    LoadingDone(this, EventArgs.Empty);
            //}
        }

        public async Task AddToDatabaseAsync(IGamePlanViewModel gamePlanModel)
        {
            log.Debug("AddToDatabaseAsync: ");

            await Task.Run(() => _database.GamePlans.Add(gamePlanModel));

            //ToDo something throws an Exception
            //GamePlans.Add(gamePlanModel);
        }

        private async Task<List<IGamePlanViewModel>> LoopThroughDatabaseParallelAsync()
        {
            log.Debug("LoopThroughDatabaseParallelAsync: ");

            List<IGamePlanViewModel> gamePlans = new List<IGamePlanViewModel>();

            await Task.Run(() =>
            {
                Parallel.ForEach<IGamePlanViewModel>(_database.GamePlans, (items) =>
                {
                    gamePlans.Add(items);
                });
                //Parallel.ForEach<IGamePlanViewModel>(gamePlans, (item) => gamePlans.Add(item));
            });

            return gamePlans.ToList();
        }

        public async Task ShowProgress()
        {
            log.Debug("ShowProgress: Has to be implemented first...");
            //ToDo Implement This
        }

        public void CancelLoading()
        {
            log.Debug("CancelLoading: Has to be implemented first...");
            //ToDo Implement This
        }





        //still here for testing purposes
        private async Task<List<IGamePlanViewModel>> LoopThroughDatabaseAsync()
        {
            log.Debug("LoopTroughDatabaseAsync: ");

            List<Task<IGamePlanViewModel>> tasks = new List<Task<IGamePlanViewModel>>();

            foreach (IGamePlanViewModel item in _database.GamePlans)
            {
                tasks.Add(Task.Run(() => item));
            }

            var _gamePlanViewModels = await Task.WhenAll(tasks);

            return _gamePlanViewModels.ToList();
        }
    }
}
