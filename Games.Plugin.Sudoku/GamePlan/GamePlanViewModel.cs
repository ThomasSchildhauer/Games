using Games.Plugin.Sudoku.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Plugin.Sudoku.GamePlan
{
    public class GamePlanViewModel : OnPropertyCange, IGamePlanViewModel
    {
        private string _planId;
        public string PlanId
        {
            get => _planId;
            set => ChangedProperty(value, ref _planId);
        }

        private int[,] _gamePlan;

        public int[,] gamePlan
        {
            get => _gamePlan;
            set => ChangedProperty<int[,]>(value, ref _gamePlan);
        }
    }
}
