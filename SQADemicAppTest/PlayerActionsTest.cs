using System;
using System.Collections.Generic;
using System.Linq;
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
                !Create.cityDictionary.TryGetValue("Kolkata", out kolkata) ||
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
            opExpert = new Player(ROLE.OpExpert);
        }

        [TestMethod]
        public void TestDriveOptions()
        {
            HashSet<City> returnedSet = PlayerActionsBL.DriveOptions(chicagoCity);
            HashSet<City> correctSet = chicagoCity.getAdjacentCities();
            CollectionAssert.AreEqual(returnedSet.ToArray(), correctSet.ToArray());
        }

        #region Direct Flight
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
        #endregion

        #region Charter Flight
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
        #endregion

        #region Shuttle Flight
        [TestMethod]
        public void TestShuttleFlightNotInStation()
        {
            //For Emily to implement
        }

        [TestMethod]
        public void TestShuttleFlightNoOptions()
        {
            scientist.currentCity = kolkata;
            kolkata.researchStation = true;
            List<String> result = PlayerActionsBL.ShuttleFlightOption(kolkata);
            kolkata.researchStation = false;
            CollectionAssert.AreEqual(new List<string>(), result);
        }

        [TestMethod]
        public void TestShuttleFlightOneOption()
        {
            scientist.currentCity = kolkata;
            kolkata.researchStation = true;
            bangkok.researchStation = true;
            List<String> result = PlayerActionsBL.ShuttleFlightOption(kolkata);
            kolkata.researchStation = false;
            bangkok.researchStation = false;
            List<String> expected = new List<String> { "Bangkok" };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestShuttleFlightMultipleOptions()
        {
            scientist.currentCity = chicagoCity;
            chicagoCity.Name = "Chicago";
            chicagoCity.researchStation = true;
            kolkata.researchStation = true;
            bangkok.researchStation = true;
            List<String> result = PlayerActionsBL.ShuttleFlightOption(chicagoCity);
            chicagoCity.researchStation = false;
            kolkata.researchStation = false;
            bangkok.researchStation = false;
            List<String> expected = new List<String> { "Kolkata", "Bangkok" };
            CollectionAssert.AreEqual(expected, result);
        }
        #endregion

        #region Move Player
        [TestMethod]
        public void TestMoverPlayerAdjacentCitySanFran()
        {
            scientist.currentCity = chicagoCity;
            hand = new List<Card> { airlift, chicagoCard, chennai };
            scientist.hand = hand;
            PlayerActionsBL.moveplayer(scientist, sanFran);
            Assert.AreEqual(scientist.currentCity.Name, sanFran.Name);
        }

        [TestMethod]
        public void TestMoverPlayerAdjacentCityChicagoWithCard()
        {
            scientist.currentCity = sanFran;
            hand = new List<Card> { airlift, chicagoCard, chennai };
            List<Card> correctHand =new List<Card> { airlift, chicagoCard, chennai };
            scientist.hand = hand;
            PlayerActionsBL.moveplayer(scientist, chicagoCity);
            Assert.AreEqual(scientist.currentCity.Name, chicagoCity.Name);
            CollectionAssert.AreEqual(correctHand, hand);
        }

        [TestMethod]
        public void TestMoverPlayerDirectFlight()
        {
            scientist.currentCity = bangkok;
            hand = new List<Card> { airlift, chicagoCard, chennai, atlanta };
            pile = new List<Card>();
            scientist.hand = hand;
            PlayerActionsBL.moveplayer(scientist, chicagoCity);
            List<Card> correctHand = new List<Card> { airlift, chennai, atlanta };
            Assert.AreEqual(scientist.currentCity.Name, chicagoCity.Name);
            CollectionAssert.AreEqual(correctHand, hand);
        }

        [TestMethod]
        public void TestMoverPlayerCharterFlight()
        {
            scientist.currentCity = chicagoCity;
            hand = new List<Card> { airlift, chicagoCard, chennai };
            pile = new List<Card>();
            scientist.hand = hand;
            PlayerActionsBL.moveplayer(scientist, bangkok);
            List<Card> correctHand = new List<Card> { airlift, chennai };
            Assert.AreEqual(scientist.currentCity.Name, bangkok.Name);
            CollectionAssert.AreEqual(correctHand, hand);
        }

        [TestMethod]
        public void TestMoverPlayerShuttleFlightPreemptCard()
        {
            chicagoCity.researchStation = true;
            bangkok.researchStation = true;
            scientist.currentCity = chicagoCity;
            hand = new List<Card> { airlift, atlanta, chennai, chicagoCard };
            pile = new List<Card>();
            scientist.hand = hand;
            Assert.AreEqual(true, PlayerActionsBL.moveplayer(scientist, bangkok));
            List<Card> correctHand = new List<Card> { airlift, atlanta, chennai, chicagoCard };
            Assert.AreEqual(scientist.currentCity.Name, bangkok.Name);
            CollectionAssert.AreEqual(correctHand, hand);
            chicagoCity.researchStation = false;
            bangkok.researchStation = false;
        }

        [TestMethod]
        public void TestMoverPlayerInvalid()
        {
            scientist.currentCity = chicagoCity;
            hand = new List<Card> { airlift, atlanta, chennai };
            pile = new List<Card>();
            scientist.hand = hand;
            Assert.AreEqual(false, PlayerActionsBL.moveplayer(scientist, bangkok));
            List<Card> correctHand = new List<Card> { airlift, atlanta, chennai };
            Assert.AreEqual(scientist.currentCity.Name, chicagoCity.Name);
            CollectionAssert.AreEqual(correctHand, hand);
        }

        #endregion

        #region BuildAResearchStation

        [TestMethod]
        public void buildStationNormal()
        {
            scientist.currentCity = chicagoCity;
            hand = new List<Card> { airlift, chicagoCard, chennai };
            scientist.hand = hand;
            List<Card> correctHand = new List<Card> { airlift, chennai };
            Assert.AreEqual(true, PlayerActionsBL.BuildAResearchStationOption(scientist));
            CollectionAssert.AreEqual(correctHand, hand);
        }

        [TestMethod]
        public void buildStationFailLackCard()
        {
            scientist.currentCity = chicagoCity;
            hand = new List<Card> { airlift, chennai };
            scientist.hand = hand;
            List<Card> correctHand = new List<Card> { airlift, chennai };
            Assert.AreEqual(false, PlayerActionsBL.BuildAResearchStationOption(scientist));
            CollectionAssert.AreEqual(correctHand, hand);
        }

        [TestMethod]
        public void buildStationFailExisting()
        {
            scientist.currentCity = chicagoCity;
            chicagoCity.researchStation = true;
            hand = new List<Card> { airlift, chicagoCard, chennai };
            scientist.hand = hand;
            List<Card> correctHand = new List<Card> { airlift, chicagoCard, chennai };
            Assert.AreEqual(false, PlayerActionsBL.BuildAResearchStationOption(scientist));
            CollectionAssert.AreEqual(correctHand, hand);
            chicagoCity.researchStation = false;
        }

        [TestMethod]
        public void buildStationOpExpert()
        {
            opExpert.currentCity = chicagoCity;
            hand = new List<Card> { airlift, chicagoCard, chennai };
            opExpert.hand = hand;
            List<Card> correctHand = new List<Card> { airlift, chicagoCard, chennai };
            Assert.AreEqual(true, PlayerActionsBL.BuildAResearchStationOption(opExpert));
            CollectionAssert.AreEqual(correctHand, hand);
        }

        [TestMethod]
        public void buildStationOpExpertWithoutCard()
        {
            opExpert.currentCity = chicagoCity;
            hand = new List<Card> { airlift, chennai };
            opExpert.hand = hand;
            List<Card> correctHand = new List<Card> { airlift, chennai };
            Assert.AreEqual(true, PlayerActionsBL.BuildAResearchStationOption(opExpert));
            CollectionAssert.AreEqual(correctHand, hand);
        }

        #endregion
    }
    /** PRINTING STUFF
    //Print Statment
    foreach (String name in returnList)
    {
        Console.Out.Write(name);
    }**/
}
