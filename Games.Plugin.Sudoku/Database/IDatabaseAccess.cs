using System.Collections.Generic;
using System.Threading.Tasks;
using Games.Plugin.Sudoku.GamePlan;

namespace Games.Plugin.Sudoku.Database
{
    public interface IDatabaseAccess
    {
        List<IGamePlanViewModel> GamePlans { get; }

        void AddToDatabase(IGamePlanViewModel gamePlanModel);
        Task LoadDatabaseAsync();
    }
}