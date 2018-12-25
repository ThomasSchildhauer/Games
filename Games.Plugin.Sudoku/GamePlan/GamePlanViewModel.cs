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
        public int[,] GamePlan
        {
            get => _gamePlan;
            set => ChangedProperty<int[,]>(value, ref _gamePlan);
        }

        private int[,] _gameStartView;

        public int[,] GameStartView
        {
            get => _gameStartView;
            set => ChangedProperty<int[,]>(value, ref _gameStartView);
        }

        public override bool Equals(object obj)
        {
            IGamePlanViewModel gamePlanViewModel = obj as IGamePlanViewModel;
            if (gamePlanViewModel == null ||
                CompareGamePlans(gamePlanViewModel ||
                CompareStartViews(gamePlanViewModel))
            {
                return false;
            }

            return true;
        }

        private bool CompareGamePlans(IGamePlanViewModel gamePlanViewModel)
        {
            var gamePlan = gamePlanViewModel.GamePlan;
            CompareArrays(gamePlan);
        }

        private bool CompareStartViews()
        {
            var gamePlan = gamePlanViewModel.StartView;
            CompareArrays(gamePlan);
        }

        //ToDo generic method...
       private bool<T> CompareArrays(T array)
           {

            for (int i = 0; i < gamePlan.GetLength(0); i++)
            {
                for (int k = 0; k < gamePlan.GetLength(1); k++)
                {
                    if (this.GamePlan[i, k] != gamePlan[i, k])
                    {
                        return false;
                    }
                }
            }

            return true;
        }


        //ToDo is not implemented jet
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        //ToDo overload of == and != Operator has to be implemented!
    }
}
