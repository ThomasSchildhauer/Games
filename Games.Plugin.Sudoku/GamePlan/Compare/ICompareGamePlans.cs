namespace Games.Plugin.Sudoku.GamePlan.Compare
{
    public interface ICompareGamePlans
    {
        bool CheckEquality(IGamePlanViewModel gamePlanViewModel1, IGamePlanViewModel gamePlanViewModel2);
        bool CompareArrays<T>(T[,] array1, T[,] array2);
        bool CompareIds(string iD1, string iD2);
    }
}