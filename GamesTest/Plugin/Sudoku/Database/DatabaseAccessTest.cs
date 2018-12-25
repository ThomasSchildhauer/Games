using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac.Extras.Moq;
using Games.Plugin.Sudoku.Database;
using Games.Plugin.Sudoku.GamePlan;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesTest.Plugin.Sudoku.Database
{
    /// <summary>
    /// Summary description for DatabaseAccessTest
    /// </summary>
    [TestClass]
    public class DatabaseAccessTest
    {
        [TestMethod]
        public async Task LoadDatabase()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IDatabase>()
                    .Setup(x => x.GamePlans)
                    .Returns(TestData.GetTestData());

                var cls = mock.Create<DatabaseAccess>();

                await cls.LoadDatabaseAsync();
                var actualData = cls.GamePlans;
                var expectedData = TestData.GetTestData();

                Assert.AreEqual(expectedData.Count, actualData.Count);

                foreach (IGamePlanViewModel item in expectedData)
                {
                    Assert.IsTrue(expectedData.Equals(actualData));
                }
            }
        }

        [TestMethod]
        public async Task AddToDatabaseTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                //Works but maybe there is a better way!! 
                mock.Mock<IDatabase>()
                    .Setup(x => x.GamePlans)
                    .Returns(TestData.GetTestData);

                var cls = mock.Create<DatabaseAccess>();
                var expectedData = TestData.GetTestDataWithAdditionalModel();

                await cls.AddToDatabaseAsync(TestData.addedModel);
                await cls.LoadDatabaseAsync();
                var actualData = cls.GamePlans;

                Assert.AreEqual(expectedData.Count, actualData.Count);
                foreach (IGamePlanViewModel item in actualData)
                {
                    Assert.IsTrue(expectedData.Contains(item));
                }
            }
        }
    }
}
