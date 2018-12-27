using Games.Plugin.Sudoku.GamePlan.Compare;

namespace Games.Plugin.Sudoku.GamePlan
{
    public interface IGamePlanViewModel
    {
        ICompareGamePlans CompareGamePlans { get; }
        int[,] GamePlan { get; set; }
        int[,] GameStartView { get; set; }
        string PlanId { get; set; }

        bool Equals(object obj);
        int GetHashCode();
    }
}