using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Plugin.Sudoku.GamePlan.Compare
{
    public class HashValues : IHashValues
    {
        //Variables
        private IGamePlanViewModel _gamePlanViewModel;


        public int GetHashCodeGamePlanViewModel(IGamePlanViewModel gamePlanViewModel)
        {
            _gamePlanViewModel = gamePlanViewModel;
            int hashStartView = GetHashCodeStartView();
            int hashPlanId = _gamePlanViewModel.PlanId.GetHashCode();
            int hashGamePlan = GetHashCodeGamePlan();

            return hashStartView + 100 * (hashPlanId + hashGamePlan);
        }

        //Methods
        private int GetHashCodeGamePlan()
        {
            var gamePlan = _gamePlanViewModel.GamePlan;
            int hashCode = 0;

            int primeNumberCount = (int)gamePlan.GetLongLength(0) * (int)gamePlan.GetLongLength(1);

            List<int> primeNumbers = PrimeNumbers.CalculatePrimeNumbers(primeNumberCount);

            for (int i = 0; i < gamePlan.GetLongLength(0); i++)
            {
                for (int k = 0; k < gamePlan.GetLongLength(1); k++)
                {
                    hashCode += gamePlan[i, k] * primeNumbers[((int)gamePlan.GetLongLength(0) * i) + k];
                }
            }

            return hashCode;
        }

        private int GetHashCodeStartView()
        {
            var gameStartView = _gamePlanViewModel.GameStartView;
            var fieldCount = from bool item in gameStartView where item == true select item;

            return fieldCount.Count();
        }
    }
}
