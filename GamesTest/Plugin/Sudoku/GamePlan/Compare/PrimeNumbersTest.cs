using Games.Plugin.Sudoku.GamePlan.Compare;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTest.Plugin.Sudoku.GamePlan.Compare
{
    [TestClass]
    public class PrimeNumbersTest
    {
        [TestMethod]
        public void CalculatePrimeNumbers1()
        {
            bool actualEqualsExpected = true;

            List<int> expected = new List<int>()
            {
                1
            };

            List<int> actual = PrimeNumbers.CalculatePrimeNumbers(1);

            for (int i = 0; i < actual.Count; i++)
            {
                if(expected[i] != actual[i])
                {
                    actualEqualsExpected = false;
                }
            }

            Assert.IsTrue(actualEqualsExpected);
        }

        [TestMethod]
        public void CalculatePrimeNumbers2()
        {
            bool actualEqualsExpected = true;

            List<int> expected = new List<int>()
            {
                1,2
            };

            List<int> actual = PrimeNumbers.CalculatePrimeNumbers(2);

            for (int i = 0; i < actual.Count; i++)
            {
                if (expected[i] != actual[i])
                {
                    actualEqualsExpected = false;
                }
            }

            Assert.IsTrue(actualEqualsExpected);
        }

        [TestMethod]
        public void CalculatePrimeNumbers3()
        {
            bool actualEqualsExpected = true;

            List<int> expected = new List<int>()
            {
                1,2,3
            };

            List<int> actual = PrimeNumbers.CalculatePrimeNumbers(3);

            for (int i = 0; i < actual.Count; i++)
            {
                if (expected[i] != actual[i])
                {
                    actualEqualsExpected = false;
                }
            }

            Assert.IsTrue(actualEqualsExpected);
        }

        [TestMethod]
        public void CalculatePrimeNumbers4()
        {
            bool actualEqualsExpected = true;

            List<int> expected = new List<int>()
            {
                1,2,3,5
            };

            List<int> actual = PrimeNumbers.CalculatePrimeNumbers(4);

            for (int i = 0; i < actual.Count; i++)
            {
                if (expected[i] != actual[i])
                {
                    actualEqualsExpected = false;
                }
            }

            Assert.IsTrue(actualEqualsExpected);
        }
    }
}
