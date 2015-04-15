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
        public void TestSettingAndGettingAdjacentCitiesSF()
        {
            create = new Create();
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
            CollectionAssert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestNYNeighbors()
        {
            create = new Create();
            StringReader r = new StringReader("New York;Montreal,Washington,London,Madrid");
            create.setAdjacentCities(r);
            List<City> result = create.getAdjacentCities("New York");
            List<City> expected = new List<City>();
            City montreal = new City(GameBoardModels.COLOR.blue);
            City washington = new City(GameBoardModels.COLOR.blue);
            City london = new City(GameBoardModels.COLOR.blue);
            City madrid = new City(GameBoardModels.COLOR.blue);
            expected.Add(montreal);
            expected.Add(washington);
            expected.Add(london);
            expected.Add(madrid);
            CollectionAssert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestMontrealNeighbors()
        {
            create = new Create();
            StringReader r = new StringReader("Montreal;New York,Washington,Chicago");
            create.setAdjacentCities(r);
            List<City> result = create.getAdjacentCities("Montreal");
            List<City> e = new List<City>();
            City newYork = new City(GameBoardModels.COLOR.blue);
            City washington = new City(GameBoardModels.COLOR.blue);
            City chicago = new City(GameBoardModels.COLOR.blue);
            e.Add(newYork);
            e.Add(washington);
            e.Add(chicago);
            CollectionAssert.AreEqual(result, e); 
        }

        [TestMethod]
        public void TestChicagoNeighbors()
        {
            create = new Create();
            StringReader r = new StringReader("Chicago;San Francisco,Los Angeles,Atlanta,Montreal");
            create.setAdjacentCities(r);
            List<City> res = create.getAdjacentCities("Chicago");
            List<City> e = new List<City>();
            City sanFrancisco = new City(GameBoardModels.COLOR.blue);
            City losAngeles = new City(GameBoardModels.COLOR.yellow);
            City atlanta = new City(GameBoardModels.COLOR.blue);
            City montreal = new City(GameBoardModels.COLOR.blue);
            e.Add(sanFrancisco);
            e.Add(losAngeles);
            e.Add(atlanta);
            e.Add(montreal);
            CollectionAssert.AreEqual(res, e);
        }

        [TestMethod]
        public void TestAtlantaNeighbors()
        {
            create = new Create();
            StringReader r = new StringReader("Atlanta;Chicago,Washington,Miami");
            create.setAdjacentCities(r);
            List<City> res = create.getAdjacentCities("Atlanta");
            List<City> e = new List<City>();
            City chicago = new City(GameBoardModels.COLOR.blue);
            City washington = new City(GameBoardModels.COLOR.blue);
            City miami = new City(GameBoardModels.COLOR.yellow);
            e.Add(chicago);
            e.Add(washington);
            e.Add(miami);
            CollectionAssert.AreEqual(res, e);

        }
    }
}
