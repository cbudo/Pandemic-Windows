using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQADemicApp.BL;
using System.Collections.Generic;

namespace SQADemicAppTest
{
    [TestClass]
    public class InfectorTest
    {
        private LinkedList<String> deck;
        private LinkedList<String> pile;
        private int[] InfectionRates = { 2, 2, 2, 3, 3, 4, 4 };
        
        [TestInitialize]
        public void SetUpArrays()
        {
            deck = new LinkedList<string>();
            //deck.AddFirst("Chicago");
            //deck.AddFirst("New York");
            //deck.AddFirst("Saint Petersburg");
            //deck.AddFirst("Sydney");
            pile = new LinkedList<string>();

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
            int infectionRate =2;
            InfectorBL.Epidemic(deck, pile, InfectionRates, 1, ref infectionRate);
            Assert.AreEqual(2, infectionRate);
        }

    }
}
