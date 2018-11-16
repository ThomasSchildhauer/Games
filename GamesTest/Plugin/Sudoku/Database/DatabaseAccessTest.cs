using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac.Extras.Moq;
using Games.Plugin.Sudoku.Database;
using Games.Plugin.Sudoku.GamePlan;
using System.Collections.Generic;

namespace GamesTest.Plugin.Sudoku.Database
{
    /// <summary>
    /// Summary description for DatabaseAccessTest
    /// </summary>
    [TestClass]
    public class DatabaseAccessTest
    {
        [TestMethod]
        public void ReadDatabase()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IDatabase>()
                    .Setup(x => x.GamePlan)
                    .Returns(TestData.GetTestData());

                var cls = mock.Create<DatabaseAccess>();

                var actualData = cls.ReadDatabase();
                var expectedData = TestData.GetTestData();

                Assert.AreEqual(expectedData, actualData);
            }
        }

        [TestMethod]
        public void AddToDatabaseTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Works but maybe there is a better way!! 
                mock.Mock<IDatabase>()
                    .Setup(x => x.GamePlan)
                    .Returns(TestData.GetTestData);

                var cls = mock.Create<DatabaseAccess>();
                var expectedData = TestData.GetTestDataWithAdditionalModel();

                cls.AddToDatabase(TestData.addedModel);
                var actualData = cls.ReadDatabase();

                Assert.AreEqual(expectedData.Count, actualData.Count);
                foreach (IGamePlanViewModel item in actualData)
                {
                    Assert.IsTrue(expectedData.Contains(item));
                }
            }
        }
    }
}
