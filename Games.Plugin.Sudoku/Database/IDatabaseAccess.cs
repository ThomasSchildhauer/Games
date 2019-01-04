using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Games.Plugin.Sudoku.GamePlan;

namespace Games.Plugin.Sudoku.Database
{
    public interface IDatabaseAccess
    {
        List<IGamePlanViewModel> GamePlans { get; }

        event EventHandler LoadingDone;

        Task AddToDatabaseAsync(IGamePlanViewModel gamePlanModel);
        void CancelLoading();
        Task LoadDatabaseAsync();
        Task ShowProgress();
    }
}