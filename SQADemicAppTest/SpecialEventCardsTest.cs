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
        InfectionDeck _deck;
        InfectionPile _pile;
        LinkedList<Cards> _answer;
        Player _dispatcher;

        [TestInitialize]
        public void SetUpCitiesandStations()
        {
            _deck = new InfectionDeck();

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
            _pile = new InfectionPile();
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
            CityCard c1 = new CityCard("New York", Color.Blue);
            CityCard c2 = new CityCard("Sydney", Color.Red);
            CityCard c3 = new CityCard("Saint Petersburg", Color.Blue);
            _pile.addCardToTop(c1);
            _pile.addCardToTop(c2);
            _pile.addCardToTop(c3);

            _answer = new LinkedList<Cards>();
            _answer.AddFirst(c1);
            _answer.AddFirst(c2);
            string city = "Saint Petersburg";
            Assert.AreEqual(true, SpecialEventCardsBl.ResilientPopulation(_pile, city));
            CollectionAssert.AreEqual(_answer, _pile.getCardList());
        }

        [TestMethod]
        public void TestRPopNewYorkMiddleCard()
        {
            _pile.Clear();
            CityCard c1 = new CityCard("New York", Color.Blue);
            CityCard c2 = new CityCard("Saint Petersburg", Color.Blue);
            CityCard c3 = new CityCard("Sydney", Color.Red);
            _pile.addCardToTop(c1);
            _pile.addCardToTop(c2);
            _pile.addCardToTop(c3);
            _answer = new LinkedList<Cards>();
            _answer.AddFirst(c1);
            _answer.AddFirst(c3);
            string city = c2.CityName;
            Assert.AreEqual(true, SpecialEventCardsBl.ResilientPopulation(_pile, city));
            CollectionAssert.AreEqual(_answer, _pile.getCardList());
        }

        [TestMethod]
        public void TestRPopNewYorkNotInPileFail()
        {
            _pile.Clear();
            CityCard c1 = new CityCard("New York", Color.Blue);
            CityCard c2 = new CityCard("Sydney", Color.Red);
            CityCard c3 = new CityCard("Saint Petersburg", Color.Blue);
            _pile.addCardToTop(c1);
            _pile.addCardToTop(c2);
            _answer = new LinkedList<Cards>();
            _answer.AddFirst(c1);
            _answer.AddFirst(c2);
            string city = c3.CityName;
            Assert.AreEqual(false, SpecialEventCardsBl.ResilientPopulation(_pile, city));
            CollectionAssert.AreEqual(_answer, _pile.getCardList());
        }
        #endregion


        #region Forecast
        [TestMethod]
        public void TestGetForcastCardsNoIssues()
        {
            _deck.Clear();
            CityCard c1 = new CityCard("Kolkata", Color.Black);
            CityCard c2 = new CityCard("Delhi", Color.Black);
            CityCard c3 = new CityCard("Chennai", Color.Black);
            CityCard c4 = new CityCard("Bangkok", Color.Red);
            CityCard c5 = new CityCard("Hong Kong", Color.Red);
            CityCard c6 = new CityCard("Chicago", Color.Blue);
            CityCard c7 = new CityCard("San Francisco", Color.Blue);
            CityCard c8 = new CityCard("Los Angeles", Color.Blue);
            CityCard c9 = new CityCard("Atlanta", Color.Blue);
            CityCard c10 = new CityCard("Montreal", Color.Blue);
            _deck.addCardToBottom(c1);
            _deck.addCardToBottom(c2);
            _deck.addCardToBottom(c3);
            _deck.addCardToBottom(c4);
            _deck.addCardToBottom(c5);
            _deck.addCardToBottom(c6);
            _deck.addCardToBottom(c7);
            _deck.addCardToBottom(c8);
            _deck.addCardToBottom(c9);
            _deck.addCardToBottom(c10);
            _answer = new LinkedList<Cards>(
                    new List<Cards> { c7, c8, c9, c10 });
            List<string> returnedListAnswer = new List<string> { c1.CityName, c2.CityName, c3.CityName, c4.CityName, c5.CityName, c6.CityName };
            List<string> returnedList = SpecialEventCardsBl.GetForcastCards(_deck);
            CollectionAssert.AreEqual(returnedListAnswer, returnedList);

        }

        [TestMethod]
        public void TestCommitForcastNoIssues()
        {
            CityCard c1 = new CityCard("Kolkata", Color.Black);
            CityCard c2 = new CityCard("Delhi", Color.Black);
            CityCard c3 = new CityCard("Chennai", Color.Black);
            CityCard c4 = new CityCard("Bangkok", Color.Red);
            CityCard c5 = new CityCard("Hong Kong", Color.Red);
            CityCard c6 = new CityCard("Chicago", Color.Blue);
            CityCard c7 = new CityCard("San Francisco", Color.Blue);
            CityCard c8 = new CityCard("Los Angeles", Color.Blue);
            CityCard c9 = new CityCard("Atlanta", Color.Blue);
            CityCard c10 = new CityCard("Montreal", Color.Blue);
            _deck.Clear();
            _deck.addCardToBottom(c1);
            _deck.addCardToBottom(c2);
            _deck.addCardToBottom(c3);
            _deck.addCardToBottom(c4);
            _deck.addCardToBottom(c5);
            _deck.addCardToBottom(c6);
            _deck.addCardToBottom(c7);
            _deck.addCardToBottom(c8);
            _deck.addCardToBottom(c9);
            _deck.addCardToBottom(c10);
            _answer = new LinkedList<Cards>( new List<Cards> { c1, c2, c3, c4, c5, c6, c7, c8, c9, c10 });
            List<string> orderedCards = new List<string> { "Kolkata", "Delhi", "Chennai", "Bangkok", "Hong Kong", "Chicago" };
            //List<string> orderedCards = SpecialEventCardsBl.GetForcastCards(_deck);
            Assert.AreEqual(true, SpecialEventCardsBl.CommitForcast(_deck, orderedCards));
            CollectionAssert.AreEqual(_answer, _deck.getCardList());
        }


        [TestMethod]
        public void TestCommitForcastTooManyOrFewCards()
        {
            CityCard c7 = new CityCard("San Francisco", Color.Blue);
            CityCard c8 = new CityCard("Los Angeles", Color.Blue);
            CityCard c9 = new CityCard("Atlanta", Color.Blue);
            CityCard c10 = new CityCard("Montreal", Color.Blue);
            _deck.Clear();
            _deck.addCardToBottom(c7);
            _deck.addCardToBottom(c8);
            _deck.addCardToBottom(c9);
            _deck.addCardToBottom(c10);
            _answer = new LinkedList<Cards>(new List<Cards> { c7, c8, c9, c10 });
            //Too Few
            List<string> orderedCards1 = new List<string> { "Kolkata", "Delhi", "Chennai", "Bangkok", "Hong Kong" };
            Assert.AreEqual(false, SpecialEventCardsBl.CommitForcast(_deck, orderedCards1));
            CollectionAssert.AreEqual(_answer, _deck.getCardList());

            //Too Many
            List<string> orderedCards2 = new List<string> { "Kolkata", "Delhi", "Chennai", "Bangkok", "Hong Kong", "San Francisco", "Los Angeles" };
            Assert.AreEqual(false, SpecialEventCardsBl.CommitForcast(_deck, orderedCards2));
            CollectionAssert.AreEqual(_answer, _deck.getCardList());
        }

        [TestMethod]
        public void TestFocastFullCircle()
        {
            _deck.Clear();
            CityCard c1 = new CityCard("Kolkata", Color.Black);
            CityCard c2 = new CityCard("Delhi", Color.Black);
            CityCard c3 = new CityCard("Chennai", Color.Black);
            CityCard c4 = new CityCard("Bangkok", Color.Red);
            CityCard c5 = new CityCard("Hong Kong", Color.Red);
            CityCard c6 = new CityCard("Chicago", Color.Blue);
            CityCard c7 = new CityCard("San Francisco", Color.Blue);
            CityCard c8 = new CityCard("Los Angeles", Color.Blue);
            CityCard c9 = new CityCard("Atlanta", Color.Blue);
            CityCard c10 = new CityCard("Montreal", Color.Blue);
            _deck.addCardToBottom(c1);
            _deck.addCardToBottom(c2);
            _deck.addCardToBottom(c3);
            _deck.addCardToBottom(c4);
            _deck.addCardToBottom(c5);
            _deck.addCardToBottom(c6);
            _deck.addCardToBottom(c7);
            _deck.addCardToBottom(c8);
            _deck.addCardToBottom(c9);
            _deck.addCardToBottom(c10);
            _answer = new LinkedList<Cards>(
                new List<Cards> { c1, c2, c3, c4, c5, c6, c7, c8, c9, c10 });
            List<string> returnedList = SpecialEventCardsBl.GetForcastCards(_deck);
            Assert.AreEqual(true, SpecialEventCardsBl.CommitForcast(_deck, returnedList));
            CollectionAssert.AreEqual(_answer, _deck.getCardList());
        }
        #endregion
    }
}
