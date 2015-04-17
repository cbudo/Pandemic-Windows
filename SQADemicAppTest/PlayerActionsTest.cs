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
        City chicago, bangkok, kolkata;
        List<GameBoardModels.Card> hand;
        GameBoardModels.Card newYork, chennai, atlanta;

        [TestInitialize]
        public void SetupPlayer()
        {
            Create setup = new Create();
            setup.createDictionary();
            /**setup.setAdjacentCities(new StringReader(SQADemicApp.Properties.Resources.AdjacentNeighbors.txt));
            if (!Create.dictOfNeighbors.TryGetValue("Chicago", out chicago))
            {
                throw new InvalidOperationException("Set up failed");
            }**/
            setup.setAdjacentCities(new StringReader("Chicago;San Francisco,Los Angeles,Atlanta,Montreal"));
            setup.setAdjacentCities(new StringReader("Bangkok;Kolkata,Hong Kong,Ho Chi Minh City,Jakarta,Chennai"));
            setup.setAdjacentCities(new StringReader("Kolkata;Delhi,Chennai,Bangkok,Hong Kong"));
            if (!Create.dictOfNeighbors.TryGetValue("Chicago", out chicago) ||
                !Create.dictOfNeighbors.TryGetValue("Bangkok", out bangkok) ||
                !Create.dictOfNeighbors.TryGetValue("Kolkata", out kolkata))
            {
                throw new InvalidOperationException("Set up failed");
            }
            newYork = new GameBoardModels.Card("New York", GameBoardModels.CARDTYPE.Player, GameBoardModels.COLOR.blue);
            chennai = new GameBoardModels.Card("chennai", GameBoardModels.CARDTYPE.Player, GameBoardModels.COLOR.black);
            atlanta = new GameBoardModels.Card("atlanta", GameBoardModels.CARDTYPE.Player, GameBoardModels.COLOR.blue);

        }

        [TestMethod]
        public void TestDirectFlightOptionsNone(){
            hand = new List<GameBoardModels.Card>();
            List<String> returnList = PlayerActionsBL.DirectFlightOption(hand, chicago);
            List<String> correctList = new List<String>();
            CollectionAssert.AreEqual(correctList, returnList);
        }

        [TestMethod]
        public void TestDirectFlightOptionNewYork()
        {
            hand = new List<GameBoardModels.Card> { newYork };
            List<String> returnList = PlayerActionsBL.DirectFlightOption(hand, chicago);
            List<String> correctList = new List<String>{newYork.CityName};
            CollectionAssert.AreEqual(correctList, returnList);
        }
    }
}
