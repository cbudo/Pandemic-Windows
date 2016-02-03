using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQADemicApp.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using SQADemicApp;

namespace SQADemicAppTest
{
    [TestClass]
    public class InfectorTest
    {
        private LinkedList<string> _deck;
        private LinkedList<string> _pile;
        private int _infectionRate;
        private int _infectionIndex;

        [TestInitialize]
        public void SetUpArrays()
        {
            new GameBoardModels(new string[] { "Dispatcher", "Operations Expert" });
            GameBoardModels.OutbreakMarker = 0;
            GameBoardModels.CubeCount.YellowCubes = 24;
            GameBoardModels.CubeCount.BlueCubes = 24;
            GameBoardModels.CubeCount.BlackCubes = 24;
            GameBoardModels.CubeCount.RedCubes = 24;
            _deck = new LinkedList<string>();
            _pile = new LinkedList<string>();
            _infectionRate = 3;
            _infectionIndex = 4;
        }

        [TestMethod]
        public void TestInfectTwoCities()
        {
            _deck.Clear(); 
            _deck.AddFirst("Saint Petersburg");
            _deck.AddFirst("Sydney");
            List<string> removedCities = InfectorBl.InfectCities(_deck, _pile, 2);
            List<string> answer = new List<string> { "Sydney", "Saint Petersburg" };
            CollectionAssert.AreEqual(answer, removedCities);
        }

        [TestMethod]
        public void TestInfectThreeCities()
        {
            _deck.Clear();
            _deck.AddFirst("Saint Petersburg");
            _deck.AddFirst("Sydney");
            _deck.AddFirst("New York");
            List<string> removedCities = InfectorBl.InfectCities(_deck, _pile, 3);
            List<string> answer = new List<string> { "New York", "Sydney", "Saint Petersburg" };
            CollectionAssert.AreEqual(answer, removedCities);
        }

        [TestMethod]
        public void TestInfectTwoCitiesTwice()
        {
            _deck.Clear();
            _deck.AddFirst("Saint Petersburg");
            _deck.AddFirst("Sydney");
            List<string> removedCities = InfectorBl.InfectCities(_deck, _pile, 2);
            List<string> answer = new List<string> { "Sydney", "Saint Petersburg" };
            CollectionAssert.AreEqual(answer, removedCities);
            _deck.AddFirst("New York");
            _deck.AddFirst("Chicago");
            removedCities = InfectorBl.InfectCities(_deck, _pile, 2);
            answer = new List<string> { "Chicago", "New York" };
            CollectionAssert.AreEqual(answer, removedCities);

        }

        [TestMethod]
        public void TestInfectTwoCitiesUpdatePile()
        {
            _deck.Clear(); 
            _deck.AddFirst("Saint Petersburg");
            _deck.AddFirst("Sydney");
            _pile = new LinkedList<string>();
            List<string> removedCities = InfectorBl.InfectCities(_deck, _pile, 2);
            LinkedList<string> answer = new LinkedList<string>();
            answer.AddFirst("Sydney");
            answer.AddFirst("Saint Petersburg");
            CollectionAssert.AreEqual(answer, _pile);
        }

        [TestMethod]
        public void TestEpidemicIncreaseInfectionCounter2To2()
        {
            _deck.Clear();
            //InfectionRates = { 2, 2, 2, 3, 3, 4, 4 };
            _deck.AddFirst("Chicago");
            _infectionIndex = 1;
            InfectorBl.Epidemic(_deck, _pile, ref _infectionIndex, ref _infectionRate);
            Assert.AreEqual(2, _infectionRate);
        }

        [TestMethod]
        public void TestEpidemicIncreaseInfectionCounter2To3()
        {
            //InfectionRates = { 2, 2, 2, 3, 3, 4, 4 };
            _deck.Clear(); 
            _deck.AddFirst("Chicago");
            _infectionIndex = 2;
            InfectorBl.Epidemic(_deck, _pile, ref _infectionIndex, ref _infectionRate);
            Assert.AreEqual(3, _infectionRate);
        }

        [TestMethod]
        public void TestEpidemicIncreaseInfectionCounter3To4()
        {
            //InfectionRates = { 2, 2, 2, 3, 3, 4, 4 };
            _deck.AddFirst("Chicago");
            _infectionRate = 3;
            _infectionIndex = 4;
            InfectorBl.Epidemic(_deck, _pile, ref _infectionIndex, ref _infectionRate);
            Assert.AreEqual(4, _infectionRate);
        }

        [TestMethod]
        public void TestEpidemicIncreaseInfectionIndex()
        {
            _deck.AddFirst("Chicago");
            _infectionRate = 3;
            _infectionIndex = 4;
            InfectorBl.Epidemic(_deck, _pile, ref _infectionIndex, ref _infectionRate);
            Assert.AreEqual(5, _infectionIndex);
        }

        [TestMethod]
        public void TestEpidemicDrawLastCardChicago()
        {
            _deck.AddFirst("Chicago");
            _deck.AddFirst("New York");
            string lastCity = InfectorBl.Epidemic(_deck, _pile, ref _infectionIndex, ref _infectionRate);
            Assert.AreEqual("Chicago", lastCity);
        }

        [TestMethod]
        public void TestEpidemicDrawLastCardNewYork()
        {
            _deck.AddFirst("New York");
            _deck.AddFirst("Chicago");
            string lastCity = InfectorBl.Epidemic(_deck, _pile, ref _infectionIndex, ref _infectionRate);
            Assert.AreEqual("New York", lastCity);
        }

        [TestMethod]
        public void TestEpidemicEmptyPileOnTopDeck()
        {
            _deck = new LinkedList<string>();
            _pile = new LinkedList<string>();
            _deck.AddFirst("New York");
            _deck.AddFirst("Chicago");
            _pile.AddFirst("Saint Petersburg");
            _pile.AddFirst("Sydney");
            InfectorBl.Epidemic(_deck, _pile, ref _infectionIndex, ref _infectionRate);
            Assert.AreEqual(0, _pile.Count);
            Assert.AreEqual(4, _deck.Count);

            //Look at print statments to manualy asses random/diffrent placing
            string[] deckarray = _deck.ToArray<String>();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(deckarray[i]);
            }
        }

        [TestMethod]
        public void TestEpidemicLastCityMixedIn()
        {
            _deck = new LinkedList<string>();
            _pile = new LinkedList<string>();
            _deck.AddFirst("Saint Petersburg");
            _deck.AddFirst("Sydney");
            _deck.AddFirst("New York");
            _deck.AddFirst("Chicago");
            string lastcity = InfectorBl.Epidemic(_deck, _pile, ref _infectionIndex, ref _infectionRate);
            Assert.AreEqual(lastcity, _deck.First.Value);
        }

      [TestMethod]
        public void TestInfectCityWithNoBlocks()
        {
            SQADemicApp.City chicago = new SQADemicApp.City(Color.Blue, "Chicago");
            int numOfBlueCubes = SQADemicApp.BL.InfectorBl.InfectCity(chicago, new HashSet<City>(), false, Color.Blue);
            Assert.AreEqual(1, numOfBlueCubes);
        }

        [TestMethod]
        public void TestInfectCityWithOneCube()
        {
            SQADemicApp.City chicago = new SQADemicApp.City(Color.Blue, "Chicago");
            chicago.BlueCubes = 1;
            int numBlueCubes = SQADemicApp.BL.InfectorBl.InfectCity(chicago, new HashSet<City>(), false, Color.Blue);
            Assert.AreEqual(2, numBlueCubes);
        }

        [TestMethod]
        public void TestInfectCityWithTwoCubes()
        {
            SQADemicApp.City chicago = new SQADemicApp.City(Color.Blue, "Chicago");
            chicago.BlueCubes = 2;
            int numBlueCubes = SQADemicApp.BL.InfectorBl.InfectCity(chicago, new HashSet<City>(), false, Color.Blue);
            Assert.AreEqual(3, numBlueCubes);
        }

        [TestMethod]
        public void TestDiffColorInfectCityWithOneCube()
        {
            SQADemicApp.City lima = new SQADemicApp.City(Color.Yellow, "Lima");
            lima.YellowCubes = 1;
            int numYellowCubes = SQADemicApp.BL.InfectorBl.InfectCity(lima, new HashSet<City>(), false, Color.Yellow);
            Assert.AreEqual(2, numYellowCubes);
            
        }

        [TestMethod]
        public void TestRedWithTwoInfect()
        {
            SQADemicApp.City tokyo = new SQADemicApp.City(Color.Red, "Tokyo");
            tokyo.RedCubes = 2;
            int numRedCubes = SQADemicApp.BL.InfectorBl.InfectCity(tokyo, new HashSet<City>(), false, Color.Red);
            Assert.AreEqual(3, numRedCubes);
        }

        [TestMethod]
        public void TestBlueInfectAndOutbreak()
        {
            SQADemicApp.City chicago = new SQADemicApp.City(Color.Blue, "Chicago");
            chicago.BlueCubes = 3;
            int numBlueCubes = SQADemicApp.BL.InfectorBl.InfectCity(chicago, new HashSet<City>(), false, Color.Blue);
            Assert.AreEqual(3, numBlueCubes);
        }

        [TestMethod]
        public void TestOutbreakSimple()
        {
            HashSet<City> infected = new HashSet<City>();
            SQADemicApp.City lima = new SQADemicApp.City(Color.Yellow, "Lima");
            SQADemicApp.City santiago = new SQADemicApp.City(Color.Yellow, "Santiago");
            infected.Add(santiago);
            santiago.AdjacentCities.Add(lima);
            santiago.YellowCubes = 3;
            SQADemicApp.BL.InfectorBl.Outbreak(santiago, Color.Yellow, santiago.AdjacentCities, infected);
            Assert.AreEqual(1, lima.YellowCubes);
        }

        [TestMethod]
        public void TestIncrementOutbreakMarker()
        {
            HashSet<City> infected = new HashSet<City>();
            SQADemicApp.City lima = new SQADemicApp.City(Color.Yellow, "Lima");
            SQADemicApp.City santiago = new SQADemicApp.City(Color.Yellow, "Santiago");
            infected.Add(santiago);
            santiago.AdjacentCities.Add(lima);
            santiago.YellowCubes = 3;
            SQADemicApp.BL.InfectorBl.Outbreak(santiago, Color.Yellow, santiago.AdjacentCities, infected);
            Assert.AreEqual(1, GameBoardModels.OutbreakMarker);
        }

        [TestMethod]
        public void TestIncrementOutbreakMarker2()
        {
            HashSet<City> infected = new HashSet<City>();
            SQADemicApp.City lima = new SQADemicApp.City(Color.Yellow, "Lima");
            SQADemicApp.City santiago = new SQADemicApp.City(Color.Yellow, "Santiago");
            infected.Add(santiago);
            santiago.AdjacentCities.Add(lima);
            santiago.YellowCubes = 3;
            GameBoardModels.OutbreakMarker += 5;
            SQADemicApp.BL.InfectorBl.Outbreak(santiago, Color.Yellow, santiago.AdjacentCities, infected);
            Assert.AreEqual(6, GameBoardModels.OutbreakMarker);
        }
        //This function didn't follow the rules of the game, Therefore this test is stupid
       /** [TestMethod]
        public void TestOneOutbreakSetOffAnotherAndOverFlowsToDifferentColor()
        {
            HashSet<City> infected = new HashSet<City>();
            SQADemicApp.City montreal = new SQADemicApp.City(COLOR.blue, "Montreal");
            SQADemicApp.City ny = new SQADemicApp.City(COLOR.blue, "New York");
            SQADemicApp.City washington = new SQADemicApp.City(COLOR.blue, "Washington");
            SQADemicApp.City chicago = new SQADemicApp.City(COLOR.blue, "Chicago");
            SQADemicApp.City atlanta = new SQADemicApp.City(COLOR.blue, "Atlanta");
            SQADemicApp.City miami = new SQADemicApp.City(COLOR.yellow, "Miami");
            montreal.blueCubes = 3;
            washington.blueCubes = 3;
            montreal.adjacentCities.Add(chicago);
            montreal.adjacentCities.Add(washington);
            montreal.adjacentCities.Add(ny);
            washington.adjacentCities.Add(ny);
            washington.adjacentCities.Add(montreal);
            washington.adjacentCities.Add(atlanta);
            washington.adjacentCities.Add(miami);
            infected.Add(montreal);
            SQADemicApp.BL.InfectorBL.InfectCity(montreal, infected, false, COLOR.blue);
            Assert.AreEqual(2, GameBoardModels.outbreakMarker); //counts both outbreaks
            Assert.AreEqual(1, miami.blueCubes); //ensures miami gets a blue overflow cube, even though it's a yellow city
            Assert.AreEqual(1, ny.blueCubes); //ensures new york only gets infected once
        }**/


        [TestMethod]
        [ExpectedException(typeof(GameLostException))]
        public void TestRedWithTwoInfectWithNewException()
        {
            SQADemicApp.City tokyo = new SQADemicApp.City(Color.Red, "Tokyo");
            tokyo.RedCubes = 2;
            GameBoardModels.CubeCount.RedCubes = 1;
            int numRedCubes = SQADemicApp.BL.InfectorBl.InfectCity(tokyo, new HashSet<City>(), false, Color.Red);
        }

        [TestMethod]
        [ExpectedException(typeof(GameLostException))]
        public void TestOutbreakSimpleException()
        {
            HashSet<City> infected = new HashSet<City>();
            SQADemicApp.City lima = new SQADemicApp.City(Color.Yellow, "Lima");
            SQADemicApp.City santiago = new SQADemicApp.City(Color.Yellow, "Santiago");
            infected.Add(santiago);
            santiago.AdjacentCities.Add(lima);
            GameBoardModels.CubeCount.YellowCubes = 1;
            santiago.YellowCubes = 3;
            SQADemicApp.BL.InfectorBl.Outbreak(santiago, Color.Yellow, santiago.AdjacentCities, infected);
        }

        [TestMethod]
        [ExpectedException(typeof(GameLostException))]
        public void TestIncrementOutbreakMarkerToThrowException()
        {
            HashSet<City> infected = new HashSet<City>();
            SQADemicApp.City lima = new SQADemicApp.City(Color.Yellow, "Lima");
            SQADemicApp.City santiago = new SQADemicApp.City(Color.Yellow, "Santiago");
            infected.Add(santiago);
            santiago.AdjacentCities.Add(lima);
            santiago.YellowCubes = 3;
            GameBoardModels.OutbreakMarker = 7;
            SQADemicApp.BL.InfectorBl.Outbreak(santiago, Color.Yellow, santiago.AdjacentCities, infected);
        }

        [TestMethod]
        public void TestDecrementTotalRedCubes()
        {
            SQADemicApp.City tokyo = new SQADemicApp.City(Color.Red, "Tokyo");
            tokyo.RedCubes = 2;
            GameBoardModels.CubeCount.RedCubes = 24;
            SQADemicApp.BL.InfectorBl.InfectCity(tokyo, new HashSet<City>(), false, Color.Red);
            Assert.AreEqual(23, GameBoardModels.CubeCount.RedCubes);
        }

        [TestMethod]
        public void TestYellowTotalCubeDecrement()
        {
            SQADemicApp.City lima = new SQADemicApp.City(Color.Yellow, "Lima");
            lima.YellowCubes = 1;
            GameBoardModels.CubeCount.YellowCubes = 23;
            SQADemicApp.BL.InfectorBl.InfectCity(lima, new HashSet<City>(), false, Color.Yellow);
            Assert.AreEqual(22, GameBoardModels.CubeCount.YellowCubes);

        }

        [TestMethod]
        public void TestDecrementTotalBlueCubes()
        {
            SQADemicApp.City chicago = new SQADemicApp.City(Color.Blue, "Chicago");
            chicago.BlueCubes = 2;
            GameBoardModels.CubeCount.BlueCubes = 22;
            SQADemicApp.BL.InfectorBl.InfectCity(chicago, new HashSet<City>(), false, Color.Blue);
            Assert.AreEqual(21, GameBoardModels.CubeCount.BlueCubes);
        }

        [TestMethod]
        public void TestDecrementTotalBlackCubes()
        {
            SQADemicApp.City kolkata = new SQADemicApp.City(Color.Black, "Kolkata");
            kolkata.BlackCubes = 2;
            GameBoardModels.CubeCount.BlackCubes = 22;
            SQADemicApp.BL.InfectorBl.InfectCity(kolkata, new HashSet<City>(), false, Color.Black);
            Console.WriteLine("INNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN : " + GameBoardModels.CubeCount.BlackCubes);
            Console.WriteLine(" " + kolkata.BlackCubes);
            Assert.AreEqual(21, GameBoardModels.CubeCount.BlackCubes);
        }

        
    }
}
