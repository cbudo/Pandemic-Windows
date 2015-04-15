using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using SQAdemicApp;

namespace SQADemicAppTest
{
    /// <summary>
    /// Summary description for NeighborTest
    /// </summary>
    [TestClass]
    public class NeighborTest
    {

        Create create;

        public NeighborTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [TestInitialize]
        private void SetUp()
        {
            create = new Create();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestSettingAndGettingAdjacentCities1()
        {
            StringReader r = new StringReader("San Francisco;Tokyo,Manila,Chicago,Los Angeles");
            create.setAdjacentCities(r);
            List<City> result = create.getAdjacentCities("San Francisco");
            List<City> expected = new List<City>();
            City tokyo = new City(GameBoardModels.COLOR.red);
            City manila = new City(GameBoardModels.COLOR.red);
            City chicago = new City(GameBoardModels.COLOR.blue);
            City losAngeles = new City(GameBoardModels.COLOR.yellow);
            expected.Add(tokyo);
            expected.Add(manila);
            expected.Add(chicago);
            expected.Add(losAngeles);
            Assert.AreEqual(result, expected);
        }
    }
}
