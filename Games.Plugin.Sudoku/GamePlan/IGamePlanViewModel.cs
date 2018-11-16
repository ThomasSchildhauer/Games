namespace Games.Plugin.Sudoku.GamePlan
{
    public interface IGamePlanViewModel
    {
        int[,] gamePlan { get; set; }
        string PlanId { get; set; }
    }
}