using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQADemicApp.BL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SQADemicAppTest
{
    [TestClass]
    class InfectorTest
    {
        private LinkedList<String> deck;
        private LinkedList<String> pile;
        private int infectionRate;
        private int infectionIndex;
        
        [TestInitialize]
        public void SetUpArrays()
        {
            deck = new LinkedList<string>();
            //deck.AddFirst("Chicago");
            //deck.AddFirst("New York");
            //deck.AddFirst("Saint Petersburg");
            //deck.AddFirst("Sydney");
            pile = new LinkedList<string>();
            infectionRate = 3;
            infectionIndex = 4;
        }

        [TestMethod]
        public void TestInfectTwoCities()
        {
            deck.AddFirst("Saint Petersburg");
            deck.AddFirst("Sydney");
            List<String> removedCities = InfectorBL.InfectCities(deck, pile, 2);
            List<String> answer = new List<string> { "Sydney", "Saint Petersburg" };
            CollectionAssert.AreEqual(answer, removedCities);
        }

        [TestMethod]
        public void TestInfectThreeCities()
        {
            deck.AddFirst("Saint Petersburg");
            deck.AddFirst("Sydney");
            deck.AddFirst("New York");
            List<String> removedCities = InfectorBL.InfectCities(deck, pile, 3);
            List<String> answer = new List<string> { "New York", "Sydney", "Saint Petersburg" };
            CollectionAssert.AreEqual(answer, removedCities);
        }

        [TestMethod]
        public void TestInfectTwoCitiesTwice()
        {
            deck.AddFirst("Saint Petersburg");
            deck.AddFirst("Sydney");
            List<String> removedCities = InfectorBL.InfectCities(deck, pile, 2);
            List<String> answer = new List<string> { "Sydney", "Saint Petersburg" };
            CollectionAssert.AreEqual(answer, removedCities);
            deck.AddFirst("New York");
            deck.AddFirst("Chicago");
            removedCities = InfectorBL.InfectCities(deck, pile, 2);
            answer = new List<string> { "Chicago", "New York" };
            CollectionAssert.AreEqual(answer, removedCities);

        }

        [TestMethod]
        public void TestInfectTwoCitiesUpdatePile()
        {
            deck.AddFirst("Saint Petersburg");
            deck.AddFirst("Sydney");
            pile = new LinkedList<String>();
            List<String> removedCities = InfectorBL.InfectCities(deck, pile, 2);
            LinkedList<String> answer = new LinkedList<string>();
            answer.AddFirst("Sydney");
            answer.AddFirst("Saint Petersburg");
            CollectionAssert.AreEqual(answer, pile);
        }

        [TestMethod]
        public void TestEpidemicIncreaseInfectionCounter2to2()
        {
            //InfectionRates = { 2, 2, 2, 3, 3, 4, 4 };
            deck.AddFirst("Chicago");
            infectionIndex = 1;
            InfectorBL.Epidemic(deck, pile, ref infectionIndex, ref infectionRate);
            Assert.AreEqual(2, infectionRate);
        }

        [TestMethod]
        public void TestEpidemicIncreaseInfectionCounter2to3()
        {
            //InfectionRates = { 2, 2, 2, 3, 3, 4, 4 };
            deck.AddFirst("Chicago");
            infectionIndex = 2;
            InfectorBL.Epidemic(deck, pile, ref infectionIndex, ref infectionRate);
            Assert.AreEqual(3, infectionRate);
        }

        [TestMethod]
        public void TestEpidemicIncreaseInfectionCounter3to4()
        {
            //InfectionRates = { 2, 2, 2, 3, 3, 4, 4 };
            deck.AddFirst("Chicago");
            infectionRate = 3;
            infectionIndex = 4;
            InfectorBL.Epidemic(deck, pile, ref infectionIndex, ref infectionRate);
            Assert.AreEqual(4, infectionRate);
        }

        [TestMethod]
        public void TestEpidemicIncreaseInfectionIndex()
        {
            deck.AddFirst("Chicago");
            infectionRate = 3;
            infectionIndex = 4;
            InfectorBL.Epidemic(deck, pile, ref infectionIndex, ref infectionRate);
            Assert.AreEqual(5, infectionIndex);
        }

        [TestMethod]
        public void TestEpidemicDrawLastCardChicago()
        {
            deck.AddFirst("Chicago");
            deck.AddFirst("New York");
            string lastCity = InfectorBL.Epidemic(deck, pile, ref infectionIndex, ref infectionRate);
            Assert.AreEqual("Chicago", lastCity);
        }

        [TestMethod]
        public void TestEpidemicDrawLastCardNewYork()
        {
            deck.AddFirst("New York");
            deck.AddFirst("Chicago");
            string lastCity = InfectorBL.Epidemic(deck, pile, ref infectionIndex, ref infectionRate);
            Assert.AreEqual("New York", lastCity);
        }

        [TestMethod]
        public void TestEpidemicEmptyPileOnTopDeck()
        {
            deck = new LinkedList<string>();
            pile = new LinkedList<string>();
            deck.AddFirst("New York");
            deck.AddFirst("Chicago");
            pile.AddFirst("Saint Petersburg");
            pile.AddFirst("Sydney");
            InfectorBL.Epidemic(deck, pile, ref infectionIndex, ref infectionRate);
            Assert.AreEqual(0, pile.Count);
            Assert.AreEqual(4, deck.Count);

            //Look at print statments to manualy asses random/diffrent placing
            string[] deckarray = deck.ToArray<String>();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(deckarray[i]);
            }
        }

        [TestMethod]
        public void TestEpidemicLastCityMixedIn()
        {
            deck = new LinkedList<string>();
            pile = new LinkedList<string>();
            deck.AddFirst("Saint Petersburg");
            deck.AddFirst("Sydney");
            deck.AddFirst("New York");
            deck.AddFirst("Chicago");
            string lastcity = InfectorBL.Epidemic(deck, pile, ref infectionIndex, ref infectionRate);
            Assert.AreEqual(lastcity, deck.First.Value);
        }
    }
}
