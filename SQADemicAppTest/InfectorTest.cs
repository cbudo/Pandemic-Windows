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
            deck.AddFirst("New York");
            deck.AddFirst("Saint Petersburg");
            deck.AddFirst("Sydney");
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
            deck.AddFirst("Chicago");
            deck.AddFirst("New York");
            removedCities = InfectorBL.InfectCities(deck, pile, 2);
            answer = new List<string> { "Chicago", "New York" };
            CollectionAssert.AreEqual(answer, removedCities);

        }

    }
}
