using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using SQADemicApp;
using SQADemicApp.BL;


namespace SQADemicAppTest
{
    [TestClass]
    public class CitiesTest
    {
        static Create create = new Create();
        static CityBL bl = new CityBL();

        [TestInitialize()]
        public void TestInitialize()
        {
            create = new Create();
            create.createDictionary();
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

        //the following tests check the getters and setters for 
        //adjacent cities list and also verify the integrity of the dictionary

        [TestMethod]
        public void TestSettingAndGettingAdjacentCitiesSF()
        {
            StringReader r = new StringReader("San Francisco;Tokyo,Manila,Chicago,Los Angeles");
            create.setAdjacentCities(r);
            List<City> result = bl.getAdjacentCities("San Francisco");
            List<City> expected = new List<City>();
            City tokyo = new City(GameBoardModels.COLOR.red, "Tokyo");
            City manila = new City(GameBoardModels.COLOR.red, "Manila");
            City chicago = new City(GameBoardModels.COLOR.blue, "Chicago");
            City losAngeles = new City(GameBoardModels.COLOR.yellow, "Los Angeles");
            expected.Add(tokyo);
            expected.Add(manila);
            expected.Add(chicago);
            expected.Add(losAngeles);
            CollectionAssert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestNYNeighbors()
        {
            StringReader r = new StringReader("New York;Montreal,Washington,London,Madrid");
            create.setAdjacentCities(r);
            List<City> result = bl.getAdjacentCities("New York");
            List<City> expected = new List<City>();
            City montreal = new City(GameBoardModels.COLOR.blue, "Montreal");
            City washington = new City(GameBoardModels.COLOR.blue, "Washington");
            City london = new City(GameBoardModels.COLOR.blue, "London");
            City madrid = new City(GameBoardModels.COLOR.blue, "Madrid");
            expected.Add(montreal);
            expected.Add(washington);
            expected.Add(london);
            expected.Add(madrid);
            CollectionAssert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestMontrealNeighbors()
        {
            StringReader r = new StringReader("Montreal;New York,Washington,Chicago");
            create.setAdjacentCities(r);
            List<City> result = bl.getAdjacentCities("Montreal");
            List<City> e = new List<City>();
            City newYork = new City(GameBoardModels.COLOR.blue, "New York");
            City washington = new City(GameBoardModels.COLOR.blue, "Washington");
            City chicago = new City(GameBoardModels.COLOR.blue, "Chicago");
            e.Add(newYork);
            e.Add(washington);
            e.Add(chicago);
            CollectionAssert.AreEqual(result, e);
        }

        [TestMethod]
        public void TestChicagoNeighbors()
        {
            StringReader r = new StringReader("Chicago;San Francisco,Los Angeles,Atlanta,Montreal");
            create.setAdjacentCities(r);
            List<City> res = bl.getAdjacentCities("Chicago");
            List<City> e = new List<City>();
            City sanFrancisco = new City(GameBoardModels.COLOR.blue, "San Francisco");
            City losAngeles = new City(GameBoardModels.COLOR.yellow, "Los Angeles");
            City atlanta = new City(GameBoardModels.COLOR.blue, "Atlanta");
            City montreal = new City(GameBoardModels.COLOR.blue, "Montreal");
            e.Add(sanFrancisco);
            e.Add(losAngeles);
            e.Add(atlanta);
            e.Add(montreal);
            CollectionAssert.AreEqual(res, e);
        }

        [TestMethod]
        public void TestAtlantaNeighbors()
        {
            StringReader r = new StringReader("Atlanta;Chicago,Washington,Miami");
            create.setAdjacentCities(r);
            List<City> res = bl.getAdjacentCities("Atlanta");
            List<City> e = new List<City>();
            City chicago = new City(GameBoardModels.COLOR.blue, "Chicago");
            City washington = new City(GameBoardModels.COLOR.blue, "Washington");
            City miami = new City(GameBoardModels.COLOR.yellow, "Miami");
            e.Add(chicago);
            e.Add(washington);
            e.Add(miami);
            CollectionAssert.AreEqual(res, e);
        }

        [TestMethod]
        public void TestWashingtonNeighbors()
        {
            StringReader r = new StringReader("Washington;Miami,Atlanta,Montreal,New York");
            create.setAdjacentCities(r);
            List<City> res = bl.getAdjacentCities("Washington");
            List<City> e = new List<City>();
            City miami = new City(GameBoardModels.COLOR.yellow, "Miami");
            City atlanta = new City(GameBoardModels.COLOR.blue, "Atlanta");
            City montreal = new City(GameBoardModels.COLOR.blue, "Montreal");
            City newYork = new City(GameBoardModels.COLOR.blue, "New York");
            e.Add(miami);
            e.Add(atlanta);
            e.Add(montreal);
            e.Add(newYork);
            CollectionAssert.AreEqual(res, e);

        }

        [TestMethod]
        public void TestResearchCityList()
        {
            Create.dictOfNeighbors["Atlanta"].researchStation = true;
            List<City> ls = new List<City>();
            City a = new City(GameBoardModels.COLOR.blue, "Atlanta");
            a.researchStation = true;
            ls.Add(a);
            List<City> result = bl.getCitiesWithResearchStations();
            CollectionAssert.AreEqual(ls, result);
        }

        [TestMethod]
        public void TestGetNeighborNames()
        {
            List<String> e = new List<String>();
            City miami = new City(GameBoardModels.COLOR.yellow, "Miami");
            City atlanta = new City(GameBoardModels.COLOR.blue, "Atlanta");
            City montreal = new City(GameBoardModels.COLOR.blue, "Montreal");
            City newYork = new City(GameBoardModels.COLOR.blue, "New York");
            e.Add(miami.Name);
            e.Add(atlanta.Name);
            e.Add(montreal.Name);
            e.Add(newYork.Name);
            List<String> result = bl.getNeighborNames("Washington");
            CollectionAssert.AreEqual(e, result);
        }

    }
}
