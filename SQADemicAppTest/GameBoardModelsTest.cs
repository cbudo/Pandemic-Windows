using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SQADemicAppTest
{
    [TestClass]
    public class GameBoardModelsTest
    {
        List<SQAdemicApp.GameBoardModels.Card> returnedList = new List<SQAdemicApp.GameBoardModels.Card>();
        List<SQAdemicApp.GameBoardModels.Card> cardList = new List<SQAdemicApp.GameBoardModels.Card>();
        SQAdemicApp.Create createTestClass = new SQAdemicApp.Create(); 
        [TestMethod]
        public void TestThatCardListCorrectOneItem()
        {
            cardList = new List<SQAdemicApp.GameBoardModels.Card>();
            cardList.Add(new SQAdemicApp.GameBoardModels.Card("test", SQAdemicApp.GameBoardModels.CARDTYPE.Player, SQAdemicApp.GameBoardModels.COLOR.blue));
            cardList.Add(new SQAdemicApp.GameBoardModels.Card("Airlift", SQAdemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQAdemicApp.GameBoardModels.Card("One Quiet Night", SQAdemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQAdemicApp.GameBoardModels.Card("Resilient Population", SQAdemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQAdemicApp.GameBoardModels.Card("Government Grant", SQAdemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQAdemicApp.GameBoardModels.Card("Forecast", SQAdemicApp.GameBoardModels.CARDTYPE.Special));
            returnedList = createTestClass.makeCardList(new System.IO.StringReader("test; blue"));
            Assert.IsTrue(cardList[0].Equals(returnedList[0]));
        }
        [TestMethod]
        public void TestThatCardListCorrectTwoItem()
        {
            cardList = new List<SQAdemicApp.GameBoardModels.Card>();
            cardList.Add(new SQAdemicApp.GameBoardModels.Card("test", SQAdemicApp.GameBoardModels.CARDTYPE.Player, SQAdemicApp.GameBoardModels.COLOR.blue));
            cardList.Add(new SQAdemicApp.GameBoardModels.Card("test2", SQAdemicApp.GameBoardModels.CARDTYPE.Player, SQAdemicApp.GameBoardModels.COLOR.blue));
            cardList.Add(new SQAdemicApp.GameBoardModels.Card("Airlift", SQAdemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQAdemicApp.GameBoardModels.Card("One Quiet Night", SQAdemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQAdemicApp.GameBoardModels.Card("Resilient Population", SQAdemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQAdemicApp.GameBoardModels.Card("Government Grant", SQAdemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQAdemicApp.GameBoardModels.Card("Forecast", SQAdemicApp.GameBoardModels.CARDTYPE.Special));
            returnedList = createTestClass.makeCardList(new System.IO.StringReader("test; blue\ntest2; blue"));
            CollectionAssert.AreEqual(cardList, returnedList);
        }
        [TestMethod]
        public void TestThatCardListCorrectThreeItem()
        {
            cardList = new List<SQAdemicApp.GameBoardModels.Card>();
            cardList.Add(new SQAdemicApp.GameBoardModels.Card("test", SQAdemicApp.GameBoardModels.CARDTYPE.Player, SQAdemicApp.GameBoardModels.COLOR.blue));
            cardList.Add(new SQAdemicApp.GameBoardModels.Card("test2", SQAdemicApp.GameBoardModels.CARDTYPE.Player, SQAdemicApp.GameBoardModels.COLOR.blue));
            cardList.Add(new SQAdemicApp.GameBoardModels.Card("test3", SQAdemicApp.GameBoardModels.CARDTYPE.Player, SQAdemicApp.GameBoardModels.COLOR.blue));
            cardList.Add(new SQAdemicApp.GameBoardModels.Card("Airlift", SQAdemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQAdemicApp.GameBoardModels.Card("One Quiet Night", SQAdemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQAdemicApp.GameBoardModels.Card("Resilient Population", SQAdemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQAdemicApp.GameBoardModels.Card("Government Grant", SQAdemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQAdemicApp.GameBoardModels.Card("Forecast", SQAdemicApp.GameBoardModels.CARDTYPE.Special));
            returnedList = createTestClass.makeCardList(new System.IO.StringReader("test; blue\ntest2; blue\ntest3; blue"));
            CollectionAssert.AreEqual(cardList, returnedList);
        }
        [TestMethod]
        public void TestThatGetsCorrectColorRed()
        {
            Assert.AreEqual(SQAdemicApp.GameBoardModels.COLOR.red, createTestClass.getColor("red"));
        }
        [TestMethod]
        public void TestThatGetsCorrectColorsRedBlue()
        {
            Assert.AreEqual(SQAdemicApp.GameBoardModels.COLOR.red, createTestClass.getColor("red"));
            Assert.AreEqual(SQAdemicApp.GameBoardModels.COLOR.blue, createTestClass.getColor("blue"));
        }
        [TestMethod]
        public void TestThatGetsCorrectThreeColors()
        {
            Assert.AreEqual(SQAdemicApp.GameBoardModels.COLOR.red, createTestClass.getColor("red"));
            Assert.AreEqual(SQAdemicApp.GameBoardModels.COLOR.blue, createTestClass.getColor("blue"));
            Assert.AreEqual(SQAdemicApp.GameBoardModels.COLOR.black, createTestClass.getColor("black"));
        }
        [TestMethod]
        public void TestThatGetsCorrectAllColors()
        {
            Assert.AreEqual(SQAdemicApp.GameBoardModels.COLOR.red, createTestClass.getColor("red"));
            Assert.AreEqual(SQAdemicApp.GameBoardModels.COLOR.blue, createTestClass.getColor("blue"));
            Assert.AreEqual(SQAdemicApp.GameBoardModels.COLOR.black, createTestClass.getColor("black"));
            Assert.AreEqual(SQAdemicApp.GameBoardModels.COLOR.yellow, createTestClass.getColor("yellow"));
        }
    }
}
