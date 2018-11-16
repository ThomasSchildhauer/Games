using System.Collections.Generic;
using System.Linq;
using Games.Plugin.Sudoku.GamePlan;

namespace GamesTest.Plugin.Sudoku.Database
{
    public static class TestData
    {
        private static readonly List<IGamePlanViewModel> _gamePlanModels = new List<IGamePlanViewModel>
            {
            new GamePlanViewModel
            {
                PlanId = "1",
                gamePlan = new int[9,9]
                {
                    { 1,2,3,4,5,6,7,8,9 },
                    { 1,2,3,4,5,6,7,8,9 },
                    { 1,2,3,4,5,6,7,8,9 },
                    { 1,2,3,4,5,6,7,8,9 },
                    { 1,2,3,4,5,6,7,8,9 },
                    { 1,2,3,4,5,6,7,8,9 },
                    { 1,2,3,4,5,6,7,8,9 },
                    { 1,2,3,4,5,6,7,8,9 },
                    { 1,2,3,4,5,6,7,8,9 }
                }
            },

            new GamePlanViewModel
            {
                PlanId = "2",
                gamePlan = new int[9, 9]
                {
                    { 9,8,7,6,5,4,3,2,1 },
                    { 9,8,7,6,5,4,3,2,1 },
                    { 9,8,7,6,5,4,3,2,1 },
                    { 9,8,7,6,5,4,3,2,1 },
                    { 9,8,7,6,5,4,3,2,1 },
                    { 9,8,7,6,5,4,3,2,1 },
                    { 9,8,7,6,5,4,3,2,1 },
                    { 9,8,7,6,5,4,3,2,1 },
                    { 9,8,7,6,5,4,3,2,1 }
                }
            }
            };

        public static List<IGamePlanViewModel> GetTestData()
        {
            return _gamePlanModels;
        }

        public static readonly GamePlanViewModel addedModel = new GamePlanViewModel
        {
            PlanId = "3",
            gamePlan = new int[9, 9]
                {
                    { 1,1,1,1,1,1,1,1,1 },
                    { 1,1,1,1,1,1,1,1,1 },
                    { 1,1,1,1,1,1,1,1,1 },
                    { 1,1,1,1,1,1,1,1,1 },
                    { 1,1,1,1,1,1,1,1,1 },
                    { 1,1,1,1,1,1,1,1,1 },
                    { 1,1,1,1,1,1,1,1,1 },
                    { 1,1,1,1,1,1,1,1,1 },
                    { 1,1,1,1,1,1,1,1,1 }
                }
        };
        private static List<IGamePlanViewModel> _gamePlanModelsWithAddedModel;

        public static List<IGamePlanViewModel> GetTestDataWithAdditionalModel()
        {
            _gamePlanModelsWithAddedModel = _gamePlanModels.ToList();
            _gamePlanModelsWithAddedModel.Add(addedModel);
            return _gamePlanModelsWithAddedModel;
        }
    }
}
