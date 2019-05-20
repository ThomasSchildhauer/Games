using GamesUI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games.Plugin.Sudoku.GamePlan.Compare
{
    public static class PrimeNumbers
    {
        private static readonly log4net.ILog log = LogHelper.GetNewLogger();

        public static List<int> CalculatePrimeNumbers(int numberCount)
        {
            log.Debug("CalculatePrimeNumbers: ");

            int number = 1;

            bool isPrimeNumber;

            List<int> _primeNumbers = new List<int>();

            do
            {
                isPrimeNumber = true;

                for (int devider = 1; devider <= number; devider++)
                {
                    if ((number % devider == 0) && ((number != devider) && (devider != 1)))
                    {
                        isPrimeNumber = false;

                        break;
                    }
                }

                if (isPrimeNumber)
                {
                    _primeNumbers.Add(number);
                }

                number++;

            } while (_primeNumbers.Count < numberCount);

            return _primeNumbers;
        }
    }
}
