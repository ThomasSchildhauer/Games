using System.Collections.Generic;
using Games.Plugin.Sudoku.GamePlan;

namespace Games.Plugin.Sudoku.Database
{
    public interface IDatabase
    {
        List<IGamePlanViewModel> GamePlan { get; set; }
    }
}