using Base.LogHelper;
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
        private static readonly log4net.ILog log = LogHelper.GetNewLogger();

        private IGamePlanViewModel _gamePlanViewModel;


        public int GetHashCodeGamePlanViewModel(IGamePlanViewModel gamePlanViewModel)
        {
            _gamePlanViewModel = gamePlanViewModel;

            var hashStartView = GetHashCodeStartView();

            var hashPlanId = _gamePlanViewModel.PlanId.GetHashCode();

            var hashGamePlan = GetHashCodeGamePlan();

            var hashCode = hashStartView + 100 * (hashPlanId + hashGamePlan);

            log.Debug(string.Format("GetHashCodeGamePlan: {0}", hashCode.ToString()));

            return hashCode;
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

            log.Debug(string.Format("GetHashCodeGamePlan: {0}", hashCode.ToString()));

            return hashCode;
        }

        private int GetHashCodeStartView()
        {
            var gameStartView = _gamePlanViewModel.GameStartView;

            var fieldCount = from bool item in gameStartView where item == true select item;

            var count = fieldCount.Count();

            log.Debug(string.Format("GetHashCodeStartView: {0}", count.ToString()));

            return count;
        }
    }
}
