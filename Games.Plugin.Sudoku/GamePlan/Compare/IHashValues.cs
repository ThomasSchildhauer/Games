namespace Games.Plugin.Sudoku.GamePlan.Compare
{
    public interface IHashValues
    {
        int GetHashCodeGamePlanViewModel(IGamePlanViewModel gamePlanViewModel);
    }
}