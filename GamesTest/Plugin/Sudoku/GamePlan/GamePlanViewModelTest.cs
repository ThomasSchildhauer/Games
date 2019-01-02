using Games.Plugin.Sudoku.GamePlan;
using Games.Plugin.Sudoku.GamePlan.Compare;
using GamesTest.Plugin.Sudoku.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTest.Plugin.Sudoku.GamePlan
{
    [TestClass]
    public class GamePlanViewModelTest
    {

        [TestMethod]
        public void EqualsTestTrue()
        {
            IGamePlanViewModel gamePlanViewModel1 = TestData.gamePlanViewModelEqualsTrue1;
            IGamePlanViewModel gamePlanViewModel2 = TestData.gamePlanViewModelEqualsTrue2;

            bool isTrue = gamePlanViewModel1.Equals(gamePlanViewModel2);

            Assert.IsTrue(isTrue);
        }

        [TestMethod]
        public void EqualsTestFasle()
        {
            IGamePlanViewModel gamePlanViewModel1 = TestData.gamePlanViewModelEqualsTrue1;
            IGamePlanViewModel gamePlanViewModel2 = TestData.gamePlanViewModelEqualsFalse;

            bool isFalse = gamePlanViewModel1.Equals(gamePlanViewModel2);

            Assert.IsFalse(isFalse);
        }
    }
}
