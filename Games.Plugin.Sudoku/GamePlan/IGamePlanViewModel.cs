namespace Games.Plugin.Sudoku.GamePlan
{
    public interface IGamePlanViewModel
    {
        int[,] GamePlan { get; set; }
        string PlanId { get; set; }
    }
}