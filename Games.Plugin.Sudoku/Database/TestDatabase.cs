using Games.Plugin.Sudoku.GamePlan;
using Games.Plugin.Sudoku.GamePlan.Compare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Plugin.Sudoku.Database
{
    public class TestDatabase : IDatabase
    {
        private List<IGamePlanViewModel> _gamePlan = new List<IGamePlanViewModel>
        {
            new GamePlanViewModel(new CompareGamePlans())
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

            new GamePlanViewModel(new CompareGamePlans())
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

        public List<IGamePlanViewModel> GamePlans
        {
            get => _gamePlan;
            set => _gamePlan = value;
        }
    }
}
