﻿using Games.Plugin.Sudoku.GamePlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games.Plugin.Sudoku.Database;
using Games.Plugin.Sudoku.Events;

namespace Games.Plugin.Sudoku.Database
{
    public class DatabaseAccess : OnPropertyCange, IDatabaseAccess, IDatabaseAccess
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
            GamePlans = await LoopThroughDatabaseAsync();
            if (LoadingDone == null)
            {
                LoadingDone(this, EventArgs.Empty);
            }
        }

        public void AddToDatabase(IGamePlanViewModel gamePlanModel)
        {
            _database.GamePlans.Add(gamePlanModel);
            GamePlans.Add(gamePlanModel);
        }

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
    }
}
