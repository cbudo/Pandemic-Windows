using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQADemicApp.BL;
using SQADemicApp;
using SQADemicApp.Players;
using System.IO;


namespace SQADemicAppTest
{
    [TestClass]
    public class SpecialEventCardsTest
    {
        City _chicagoCity, _bangkok, _kolkata, _sanFran;
        LinkedList<string> _deck, _pile, _answer;
        Player _dispatcher;

        [TestInitialize]
        public void SetUpCitiesandStations()
        {
            //set up GameboardModels if not already
            var g = new GameBoardModels(new string[] { "dispatcher", "medic" });
            //cities
            Create.CreateDictionary();
            Create.SetAdjacentCities(new StringReader("Chicago;San Francisco,Los Angeles,Atlanta,Montreal"));
            Create.SetAdjacentCities(new StringReader("Bangkok;Kolkata,Hong Kong,Ho Chi Minh City,Jakarta,Chennai"));
            Create.SetAdjacentCities(new StringReader("Kolkata;Delhi,Chennai,Bangkok,Hong Kong"));
            Create.SetAdjacentCities(new StringReader("San Francisco;Tokyo,Manila,Chicago,Los Angeles"));
            if (!Create.CityDictionary.TryGetValue("Chicago", out _chicagoCity) ||
                !Create.CityDictionary.TryGetValue("Bangkok", out _bangkok) ||
                !Create.CityDictionary.TryGetValue("Kolkata", out _kolkata) ||
                !Create.CityDictionary.TryGetValue("San Francisco", out _sanFran))
            {
                throw new InvalidOperationException("Set up failed");
            }
            //players
            _dispatcher = new Dispatcher();
            _pile = new LinkedList<string>();
        }

        #region GovernmentGrant

        [TestMethod]
        public void TestGovernmentGrantChicago()
        {
            Assert.AreEqual(true, SpecialEventCardsBl.GovernmentGrant(_chicagoCity.Name));
            Assert.AreEqual(true, _chicagoCity.ResearchStation);
            _chicagoCity.ResearchStation = false;
        }

        [TestMethod]
        public void TestGovernmentGrantkolkataFailed()
        {
            //already has a research station should fail
            _kolkata.ResearchStation = true;
            Assert.AreEqual(false, SpecialEventCardsBl.GovernmentGrant(_kolkata.Name));
            Assert.AreEqual(true, _kolkata.ResearchStation);
            _kolkata.ResearchStation = false;
        }

        #endregion

        #region AirLift
        [TestMethod]
        public void TestAirliftBankokToChicago()
        {
            _dispatcher.CurrentCity = _bangkok;
            Assert.AreEqual(true, SpecialEventCardsBl.Airlift(_dispatcher, _chicagoCity));
            Assert.AreEqual(_dispatcher.CurrentCity, _chicagoCity);
        }

        [TestMethod]
        public void TestAirliftChicagoToChicagoFail()
        {
            _dispatcher.CurrentCity = _chicagoCity;
            Assert.AreEqual(false, SpecialEventCardsBl.Airlift(_dispatcher, _chicagoCity));
            Assert.AreEqual(_dispatcher.CurrentCity, _chicagoCity);
        }

        #endregion

        #region ResilientPopulation
        [TestMethod]
        public void TestRPopNewYork()
        {
            _pile.Clear();
            _pile.AddFirst("New York");
            _pile.AddFirst("Sydney");
            _pile.AddFirst("Saint Petersburg");
            _answer = new LinkedList<string>();
            _answer.AddFirst("New York");
            _answer.AddFirst("Sydney");
            string city = "Saint Petersburg";
            Assert.AreEqual(true, SpecialEventCardsBl.ResilientPopulation(_pile, city));
            CollectionAssert.AreEqual(_answer, _pile);
        }

        [TestMethod]
        public void TestRPopNewYorkMiddleCard()
        {
            _pile.Clear();
            _pile.AddFirst("New York");
            _pile.AddFirst("Saint Petersburg");
            _pile.AddFirst("Sydney");
            _answer = new LinkedList<string>();
            _answer.AddFirst("New York");
            _answer.AddFirst("Sydney");
            string city = "Saint Petersburg";
            Assert.AreEqual(true, SpecialEventCardsBl.ResilientPopulation(_pile, city));
            CollectionAssert.AreEqual(_answer, _pile);
        }

        [TestMethod]
        public void TestRPopNewYorkNotInPileFail()
        {
            _pile.Clear();
            _pile.AddFirst("New York");
            _pile.AddFirst("Sydney");
            _answer = new LinkedList<string>();
            _answer.AddFirst("New York");
            _answer.AddFirst("Sydney");
            string city = "Saint Petersburg";
            Assert.AreEqual(false, SpecialEventCardsBl.ResilientPopulation(_pile, city));
            CollectionAssert.AreEqual(_answer, _pile);
        }
        #endregion


        #region Forecast
        [TestMethod]
        public void TestGetForcastCardsNoIssues()
        {
            _deck = new LinkedList<string>(
                    new List<string> { "Kolkata", "Delhi", "Chennai", "Bangkok", "Hong Kong", "Chicago", "San Francisco", "Los Angeles", "Atlanta", "Montreal" });
            _answer = new LinkedList<string>(
                    new List<string> { "San Francisco", "Los Angeles", "Atlanta", "Montreal" });
            List<string> returnedListAnswer = new List<string> { "Kolkata", "Delhi", "Chennai", "Bangkok", "Hong Kong", "Chicago" };

            List<string> returnedList = SpecialEventCardsBl.GetForcastCards(_deck);
            CollectionAssert.AreEqual(returnedListAnswer, returnedList);
            CollectionAssert.AreEqual(_answer, _deck);

        }

        [TestMethod]
        public void TestCommitForcastNoIssues()
        {
            _answer = new LinkedList<string>(
                    new List<string> { "Kolkata", "Delhi", "Chennai", "Bangkok", "Hong Kong", "Chicago", "San Francisco", "Los Angeles", "Atlanta", "Montreal" });
            _deck = new LinkedList<string>(
                    new List<string> { "San Francisco", "Los Angeles", "Atlanta", "Montreal" });
            List<string> orderedCards = new List<string> { "Kolkata", "Delhi", "Chennai", "Bangkok", "Hong Kong", "Chicago" };

            Assert.AreEqual(true, SpecialEventCardsBl.CommitForcast(_deck, orderedCards));
            CollectionAssert.AreEqual(_answer, _deck);
        }


        [TestMethod]
        public void TestCommitForcastTooManyOrFewCards()
        {
            _answer = new LinkedList<string>(
                    new List<string> { "San Francisco", "Los Angeles", "Atlanta", "Montreal" });
            _deck = new LinkedList<string>(
                    new List<string> { "San Francisco", "Los Angeles", "Atlanta", "Montreal" });

            //Too Few
            List<string> orderedCards1 = new List<string> { "Kolkata", "Delhi", "Chennai", "Bangkok", "Hong Kong" };
            Assert.AreEqual(false, SpecialEventCardsBl.CommitForcast(_deck, orderedCards1));
            CollectionAssert.AreEqual(_answer, _deck);

            //Too Many
            List<string> orderedCards2 = new List<string> { "Kolkata", "Delhi", "Chennai", "Bangkok", "Hong Kong", "San Francisco", "Los Angeles" };
            Assert.AreEqual(false, SpecialEventCardsBl.CommitForcast(_deck, orderedCards2));
            CollectionAssert.AreEqual(_answer, _deck);
        }

        [TestMethod]
        public void TestFocastFullCircle()
        {
            _deck = new LinkedList<string>(
                new List<string> { "Kolkata", "Delhi", "Chennai", "Bangkok", "Hong Kong", "Chicago", "San Francisco", "Los Angeles", "Atlanta", "Montreal" });
            _answer = new LinkedList<string>(
                new List<string> { "Kolkata", "Delhi", "Chennai", "Bangkok", "Hong Kong", "Chicago", "San Francisco", "Los Angeles", "Atlanta", "Montreal" });
            List<string> returnedList = SpecialEventCardsBl.GetForcastCards(_deck);
            Assert.AreEqual(true, SpecialEventCardsBl.CommitForcast(_deck, returnedList));
            CollectionAssert.AreEqual(_answer, _deck);
        }
        #endregion
    }
}
