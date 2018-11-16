using Games.Plugin.Sudoku.GamePlan;
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

        public List<IGamePlanViewModel> GamePlan
        {
            get => _gamePlan;
            set => _gamePlan = value;
        }
    }
}
