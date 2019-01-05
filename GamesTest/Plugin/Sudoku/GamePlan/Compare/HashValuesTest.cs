using Games.Plugin.Sudoku.GamePlan;
using GamesTest.Plugin.Sudoku.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTest.Plugin.Sudoku.GamePlan.Compare
{
    [TestClass]
    public class HashValuesTest
    {
        [TestMethod]
        public void GetHashCodeGamePlanViewModelTestAreEqual()
        {
            IGamePlanViewModel gamePlanViewModel1 = TestData.gamePlanViewModelEqualsTrue1;
            IGamePlanViewModel gamePlanViewModel2 = TestData.gamePlanViewModelEqualsTrue2;

            Assert.AreEqual(gamePlanViewModel1.GetHashCode(), gamePlanViewModel2.GetHashCode());
        }

        [TestMethod]
        public void GetHashCodeGamePlanViewModelTestAreNotEqual()
        {
            IGamePlanViewModel gamePlanViewModel1 = TestData.gamePlanViewModelEqualsTrue1;
            IGamePlanViewModel gamePlanViewModel2 = TestData.gamePlanViewModelEqualsFalse;

            Assert.AreNotEqual(gamePlanViewModel1.GetHashCode(), gamePlanViewModel2.GetHashCode());
        }
    }
}
