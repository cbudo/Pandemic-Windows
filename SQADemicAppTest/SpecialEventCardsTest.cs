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
    public class SpecialEventCardsTest
    {
        City chicagoCity, bangkok, kolkata, sanFran;
        Player dispatcher;
        [TestInitialize]
        public void setUpCitiesandStations()
        {
            //set up GameboardModels if not already
            var g = new GameBoardModels(new string[] { "dispatcher", "medic" });
            //cities
            Create.createDictionary();
            Create.setAdjacentCities(new StringReader("Chicago;San Francisco,Los Angeles,Atlanta,Montreal"));
            Create.setAdjacentCities(new StringReader("Bangkok;Kolkata,Hong Kong,Ho Chi Minh City,Jakarta,Chennai"));
            Create.setAdjacentCities(new StringReader("Kolkata;Delhi,Chennai,Bangkok,Hong Kong"));
            Create.setAdjacentCities(new StringReader("San Francisco;Tokyo,Manila,Chicago,Los Angeles"));
            if (!Create.cityDictionary.TryGetValue("Chicago", out chicagoCity) ||
                !Create.cityDictionary.TryGetValue("Bangkok", out bangkok) ||
                !Create.cityDictionary.TryGetValue("Kolkata", out kolkata) ||
                !Create.cityDictionary.TryGetValue("San Francisco", out sanFran))
            {
                throw new InvalidOperationException("Set up failed");
            }
            //players
            dispatcher = new Player(ROLE.Dispatcher);
        }

        #region GovernmentGrant

        [TestMethod]
        public void TestGovernmentGrantChicago()
        {
            Assert.AreEqual(true, SpecialEventCardsBL.GovernmentGrant(chicagoCity.Name));
            Assert.AreEqual(true, chicagoCity.researchStation);
            chicagoCity.researchStation = false;
        }

        [TestMethod]
        public void TestGovernmentGrantkolkataFAILED()
        {
            //already has a research station should fail
            kolkata.researchStation = true;
            Assert.AreEqual(false, SpecialEventCardsBL.GovernmentGrant(kolkata.Name));
            Assert.AreEqual(true, kolkata.researchStation);
            kolkata.researchStation = false;
        }

#endregion

        #region AirLift
        [TestMethod]
        public void TestAirliftBankokToChicago()
        {
            dispatcher.currentCity = bangkok;
            Assert.AreEqual(true, SpecialEventCardsBL.Airlift(dispatcher, chicagoCity));
            Assert.AreEqual(dispatcher.currentCity , chicagoCity);
        }

        #endregion

    }
}
