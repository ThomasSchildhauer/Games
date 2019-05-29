using GalaSoft.MvvmLight;
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
    public class GamePlanViewModel : ViewModelBase, IGamePlanViewModel
    {
        //Variables and Properties
        private readonly ICompareGamePlans _compareGamePlans;
        private readonly IHashValues _hashValues;

        private string _planId;
        public string PlanId
        {
            get => _planId;
            set => Set(nameof(PlanId), ref _planId, value);
        }

        private int[,] _gamePlan;
        public int[,] GamePlan
        {
            get => _gamePlan;
            set => Set<int[,]>(nameof(GamePlan), ref _gamePlan, value);
        }

        private bool[,] _gameStartView;
        public bool[,] GameStartView
        {
            get => _gameStartView;
            set => Set<bool[,]>(nameof(GameStartView), ref _gameStartView, value);
        }

        private bool _ucIsVisible = false;

        public bool UcIsVisible
        {
            get => _ucIsVisible;
            set => Set(nameof(UcIsVisible), ref _ucIsVisible, value);
        }

        //Constructor
        public GamePlanViewModel(ICompareGamePlans compareGamePlans, IHashValues hashValues)
        {
            _compareGamePlans = compareGamePlans;
            _hashValues = hashValues;
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

        public override int GetHashCode()
        {
            return CalculateHashCode(_hashValues.GetHashCodeGamePlanViewModel);
        }

        private int CalculateHashCode(Func<GamePlanViewModel, int> function)
        {
            return function(this);
        }

        //ToDo overload of == and != Operator has to be implemented!
    }
}
