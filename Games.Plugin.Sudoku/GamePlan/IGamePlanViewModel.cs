namespace Games.Plugin.Sudoku.GamePlan
{
    public interface IGamePlanViewModel
    {
        int[,] GamePlan { get; set; }
        bool[,] GameStartView { get; set; }
        string PlanId { get; set; }
        bool UcIsVisible { get; set; }

        bool Equals(object obj);
        int GetHashCode();
    }
}