using System.Collections.Generic;
using System.Linq;
using Games.Plugin.Sudoku.GamePlan;
using Games.Plugin.Sudoku.GamePlan.Compare;

namespace GamesTest.Plugin.Sudoku.Database
{
    public static class TestData
    {
        private static readonly List<IGamePlanViewModel> _gamePlanModels = new List<IGamePlanViewModel>
            {

            new GamePlanViewModel(new CompareGamePlans(), new HashValues())
            {
                PlanId = "1",
                GamePlan = new int[9,9]
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

            new GamePlanViewModel(new CompareGamePlans(), new HashValues())
            {
                PlanId = "2",
                GamePlan = new int[9, 9]
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

        public static readonly GamePlanViewModel addedModel = new GamePlanViewModel(new CompareGamePlans(), new HashValues())
        {
            PlanId = "3",
            GamePlan = new int[9, 9]
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

        public static IGamePlanViewModel gamePlanViewModelEqualsTrue1 = new GamePlanViewModel(new CompareGamePlans(), new HashValues())
        {
            PlanId = "1",

            GamePlan = new int[9, 9]
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
                },

            GameStartView = new bool[9, 9]
                {
                    { false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, false },
                }
        };

        public static IGamePlanViewModel gamePlanViewModelEqualsTrue2 = new GamePlanViewModel(new CompareGamePlans(), new HashValues())
        {
            PlanId = "1",

            GamePlan = new int[9, 9]
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
            },

            GameStartView = new bool[9, 9]
            {
                    { false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, false },
            }
        };

        public static IGamePlanViewModel gamePlanViewModelEqualsFalse = new GamePlanViewModel(new CompareGamePlans(), new HashValues())
        {
            PlanId = "2",

            GamePlan = new int[9, 9]
            {
                    { 1,2,3,4,5,6,7,8,9 },
                    { 1,2,3,4,5,6,7,8,9 },
                    { 1,2,3,4,5,6,7,8,9 },
                    { 1,2,3,4,5,6,7,8,9 },
                    { 1,2,3,4,5,6,7,8,9 },
                    { 1,2,3,4,5,6,7,8,9 },
                    { 1,2,3,4,5,6,7,8,9 },
                    { 1,2,3,4,5,6,7,8,9 },
                    { 1,2,3,4,5,6,7,8,1 }
            },

            GameStartView = new bool[9, 9]
            {
                    { false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false, false, true },
            }
        };
    }
}
