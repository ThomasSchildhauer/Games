using System.Collections.Generic;
using Games.Plugin.Sudoku.GamePlan;

namespace Games.Plugin.Sudoku.Database
{
    public interface IDatabaseAccess
    {
        void AddToDatabase(IGamePlanViewModel gamePlanModel);
        List<IGamePlanViewModel> ReadDatabase();
    }
}