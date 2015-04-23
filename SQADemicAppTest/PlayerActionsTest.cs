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
        City chicagoCity, bangkok, kolkata, sanFran;
        List<Card> hand, pile;
        Card newYork, chennai, atlanta, chicagoCard, airlift;
        Player dispatcher, medic, opExpert, researcher, scientist;

        [TestInitialize]
        public void SetupPlayer()
        {
            //cities
            Create setup = new Create();
            setup.createDictionary();
            setup.setAdjacentCities(new StringReader("Chicago;San Francisco,Los Angeles,Atlanta,Montreal"));
            setup.setAdjacentCities(new StringReader("Bangkok;Kolkata,Hong Kong,Ho Chi Minh City,Jakarta,Chennai"));
            setup.setAdjacentCities(new StringReader("Kolkata;Delhi,Chennai,Bangkok,Hong Kong"));
            setup.setAdjacentCities(new StringReader("San Francisco;Tokyo,Manila,Chicago,Los Angeles"));
            if (!Create.cityDictionary.TryGetValue("Chicago", out chicagoCity) ||
                !Create.cityDictionary.TryGetValue("Bangkok", out bangkok) ||
                !Create.cityDictionary.TryGetValue("Kolkata", out kolkata)||
                !Create.cityDictionary.TryGetValue("San Francisco", out sanFran))
            {
                throw new InvalidOperationException("Set up failed");
            }
            //Cards
            newYork = new Card("New York", Card.CARDTYPE.City, COLOR.blue);
            chennai = new Card("Chennai", Card.CARDTYPE.City, COLOR.black);
            atlanta = new Card("Atlanta", Card.CARDTYPE.City, COLOR.blue);
            chicagoCard = new Card("Chicago", Card.CARDTYPE.City, COLOR.blue);
            airlift = new SQADemicApp.Card("Airlift", SQADemicApp.Card.CARDTYPE.Special);
            //Players
            scientist = new Player(ROLE.Scientist);
        }

        [TestMethod]
        public void TestDirectFlightOptionsNone()
        {
            hand = new List<Card>();
            List<String> returnList = PlayerActionsBL.DirectFlightOption(hand, chicagoCity);
            List<String> correctList = new List<String>();
            CollectionAssert.AreEqual(correctList, returnList);
        }

        [TestMethod]
        public void TestDirectFlightOptionNewYork()
        {
            hand = new List<Card> { newYork };
            List<String> returnList = PlayerActionsBL.DirectFlightOption(hand, chicagoCity);
            List<String> correctList = new List<String> { newYork.CityName };
            CollectionAssert.AreEqual(correctList, returnList);
        }

        [TestMethod]
        public void TestDirectFlightCurrentCityChicago()
        {
            hand = new List<Card> { chicagoCard };
            List<String> returnList = PlayerActionsBL.DirectFlightOption(hand, chicagoCity);
            List<String> correctList = new List<String>();
            CollectionAssert.AreEqual(correctList, returnList);
        }

        [TestMethod]
        public void TestDirectFlightMultipleCities()
        {
            hand = new List<Card> { chicagoCard, atlanta, chennai };
            List<String> returnList = PlayerActionsBL.DirectFlightOption(hand, chicagoCity);
            List<String> correctList = new List<String> { atlanta.CityName, chennai.CityName };
            CollectionAssert.AreEqual(correctList, returnList);
        }

        [TestMethod]
        public void TestDirectFlightWithNonCityCardInHand()
        {
            hand = new List<Card> { airlift, atlanta, chennai };
            List<String> returnList = PlayerActionsBL.DirectFlightOption(hand, chicagoCity);
            List<String> correctList = new List<String> { atlanta.CityName, chennai.CityName };
            CollectionAssert.AreEqual(correctList, returnList);
            
        }

            /** PRINTING STUFF
            //Print Statment
            foreach (String name in returnList)
            {
                Console.Out.Write(name);
            }**/

        [TestMethod]
        public void TestCharterFlightFalseOption()
        {
            hand = new List<Card> { airlift, atlanta, chennai };
            bool returendBool = PlayerActionsBL.CharterFlightOption(hand, chicagoCity);
            bool correctBool = false;
            Assert.AreEqual(correctBool, returendBool);
        }

        [TestMethod]
        public void TestCharterFlightTrue()
        {
            hand = new List<Card> { airlift, atlanta, chicagoCard };
            bool returendBool = PlayerActionsBL.CharterFlightOption(hand, chicagoCity);
            bool correctBool = true;
            Assert.AreEqual(correctBool, returendBool);
        }  

        [TestMethod]
        public void TestMoverPlayerAdjacentCitySanFran()
        {
            scientist.currentCity = chicagoCity;
            PlayerActionsBL.moveplayer(scientist,sanFran);
            Assert.AreEqual(scientist.currentCity.Name, sanFran.Name);
        }

      /**  [TestMethod]
        public void TestMoverPlayerAdjacentCityChicago()
        {
            scientist.currentCity = sanFran;
            PlayerActionsBL.moveplayer(scientist, chicagoCity);
            Assert.AreEqual(scientist.currentCity.Name, chicagoCity.Name);
        }**/

        [TestMethod]
        public void TestMoverPlayerDirectFlight()
        {
            
            scientist.currentCity = bangkok;
            hand = new List<Card> { airlift, chicagoCard, chennai };
            pile = new List<Card>();
            scientist.hand = hand;
            PlayerActionsBL.moveplayer(scientist, chicagoCity);
            hand = new List<Card> { airlift, chennai };
            Assert.AreEqual(scientist.currentCity.Name, chicagoCity.Name);

        }
    }
}
