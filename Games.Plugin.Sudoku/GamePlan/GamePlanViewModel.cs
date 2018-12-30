using Games.Plugin.Sudoku.Events;
using Games.Plugin.Sudoku.GamePlan.Compare;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Plugin.Sudoku.GamePlan
{
    public class GamePlanViewModel : OnPropertyCange, IGamePlanViewModel
    {
        //Variables and Properties
        private string _planId;
        private readonly ICompareGamePlans _compareGamePlans;
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


        //Constructor
        public GamePlanViewModel(ICompareGamePlans compareGamePlans)
        {
            _compareGamePlans = compareGamePlans;
        }


        //Methods
        public override bool Equals(object obj)
        {
            IGamePlanViewModel gamePlanViewModel = obj as IGamePlanViewModel;
            if (gamePlanViewModel == null)
            {
                return false;
            }

            return TestEquality(this, gamePlanViewModel, _compareGamePlans.CheckEquality);
        }

        private bool TestEquality(IGamePlanViewModel gamePlanViewModel1, IGamePlanViewModel gamePlanViewModel2,
            Func<IGamePlanViewModel, IGamePlanViewModel, bool> compareGamePlans)
        {
            return compareGamePlans(gamePlanViewModel1, gamePlanViewModel2);
        }

        //ToDo is not implemented jet
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        //ToDo overload of == and != Operator has to be implemented!
    }
}
