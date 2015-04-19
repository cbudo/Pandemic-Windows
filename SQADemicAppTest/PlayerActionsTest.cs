using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQADemicApp.BL;
using SQADemicApp;
using System.IO;

namespace SQADemicAppTest
{
    [TestClass]
    public class PlayerActionsTest
    {
        City chicagoCity, bangkok, kolkata;
        List<GameBoardModels.Card> hand;
        GameBoardModels.Card newYork, chennai, atlanta, chicagoCard;

        [TestInitialize]
        public void SetupPlayer()
        {
            //cities
            Create setup = new Create();
            setup.createDictionary();
            setup.setAdjacentCities(new StringReader("Chicago;San Francisco,Los Angeles,Atlanta,Montreal"));
            setup.setAdjacentCities(new StringReader("Bangkok;Kolkata,Hong Kong,Ho Chi Minh City,Jakarta,Chennai"));
            setup.setAdjacentCities(new StringReader("Kolkata;Delhi,Chennai,Bangkok,Hong Kong"));
            if (!Create.dictOfNeighbors.TryGetValue("Chicago", out chicagoCity) ||
                !Create.dictOfNeighbors.TryGetValue("Bangkok", out bangkok) ||
                !Create.dictOfNeighbors.TryGetValue("Kolkata", out kolkata))
            {
                throw new InvalidOperationException("Set up failed");
            }
            //Cards
            newYork = new GameBoardModels.Card("New York", GameBoardModels.CARDTYPE.Player, GameBoardModels.COLOR.blue);
            chennai = new GameBoardModels.Card("Chennai", GameBoardModels.CARDTYPE.Player, GameBoardModels.COLOR.black);
            atlanta = new GameBoardModels.Card("Atlanta", GameBoardModels.CARDTYPE.Player, GameBoardModels.COLOR.blue);
            chicagoCard = new GameBoardModels.Card("Chicago", GameBoardModels.CARDTYPE.Player, GameBoardModels.COLOR.blue);

        }

        [TestMethod]
        public void TestDirectFlightOptionsNone(){
            hand = new List<GameBoardModels.Card>();
            List<String> returnList = PlayerActionsBL.DirectFlightOption(hand, chicagoCity);
            List<String> correctList = new List<String>();
            CollectionAssert.AreEqual(correctList, returnList);
        }

        [TestMethod]
        public void TestDirectFlightOptionNewYork()
        {
            hand = new List<GameBoardModels.Card> { newYork };
            List<String> returnList = PlayerActionsBL.DirectFlightOption(hand, chicagoCity);
            List<String> correctList = new List<String>{newYork.CityName};
            CollectionAssert.AreEqual(correctList, returnList);
        }

        [TestMethod]
        public void TestDirectFlightCurrentCityChicago()
        {
            hand = new List<GameBoardModels.Card> { chicagoCard };
            List<String> returnList = PlayerActionsBL.DirectFlightOption(hand, chicagoCity);
            List<String> correctList = new List<String>();
            CollectionAssert.AreEqual(correctList, returnList);
        }

        [TestMethod]
        public void TestDirectFlightMultipleCities()
        {
            hand = new List<GameBoardModels.Card> { chicagoCard, atlanta, chennai };
            List<String> returnList = PlayerActionsBL.DirectFlightOption(hand, chicagoCity);
            List<String> correctList = new List<String> { atlanta.CityName, chennai.CityName};
            CollectionAssert.AreEqual(correctList, returnList);
        }
    }
}
