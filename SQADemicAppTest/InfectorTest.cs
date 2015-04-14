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
            deck.AddFirst("Chicago");
            deck.AddFirst("New York");
            deck.AddFirst("Saint Petersburg");
            deck.AddFirst("Sydney");
            pile = new LinkedList<string>();

        }


        [TestMethod]
        public void TestInfectTwoCities()
        {
            List<String> removedCities = InfectorBL.InfectCities(deck, pile, 2);
            List<String> answer = new List<string> { "Sydney", "Saint Petersburg" };
            Assert.AreEqual<String>(answer.ToString(), removedCities.ToString());

        }
    }
}
