using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SQADemicApp.BL;

namespace SQADemicAppTest
{
    [TestClass]
    public class GameBoardModelsTest
    {
        List<SQADemicApp.GameBoardModels.Card> returnedList = new List<SQADemicApp.GameBoardModels.Card>();
        List<SQADemicApp.GameBoardModels.Card> cardList = new List<SQADemicApp.GameBoardModels.Card>();
        SQADemicApp.Create createTestClass = new SQADemicApp.Create(); 
        [TestMethod]
        public void TestThatCardListCorrectOneItem()
        {
            cardList = new List<SQADemicApp.GameBoardModels.Card>();
            cardList.Add(new SQADemicApp.GameBoardModels.Card("test", SQADemicApp.GameBoardModels.CARDTYPE.Player, SQADemicApp.GameBoardModels.COLOR.blue));
            cardList.Add(new SQADemicApp.GameBoardModels.Card("Airlift", SQADemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQADemicApp.GameBoardModels.Card("One Quiet Night", SQADemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQADemicApp.GameBoardModels.Card("Resilient Population", SQADemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQADemicApp.GameBoardModels.Card("Government Grant", SQADemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQADemicApp.GameBoardModels.Card("Forecast", SQADemicApp.GameBoardModels.CARDTYPE.Special));
            returnedList = createTestClass.makeCardList(new System.IO.StringReader("test; blue"));
            Assert.IsTrue(cardList[0].Equals(returnedList[0]));
        }
        [TestMethod]
        public void TestThatCardListCorrectTwoItem()
        {
            cardList = new List<SQADemicApp.GameBoardModels.Card>();
            cardList.Add(new SQADemicApp.GameBoardModels.Card("test", SQADemicApp.GameBoardModels.CARDTYPE.Player, SQADemicApp.GameBoardModels.COLOR.blue));
            cardList.Add(new SQADemicApp.GameBoardModels.Card("test2", SQADemicApp.GameBoardModels.CARDTYPE.Player, SQADemicApp.GameBoardModels.COLOR.blue));
            cardList.Add(new SQADemicApp.GameBoardModels.Card("Airlift", SQADemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQADemicApp.GameBoardModels.Card("One Quiet Night", SQADemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQADemicApp.GameBoardModels.Card("Resilient Population", SQADemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQADemicApp.GameBoardModels.Card("Government Grant", SQADemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQADemicApp.GameBoardModels.Card("Forecast", SQADemicApp.GameBoardModels.CARDTYPE.Special));
            returnedList = createTestClass.makeCardList(new System.IO.StringReader("test; blue\ntest2; blue"));
            CollectionAssert.AreEqual(cardList, returnedList);
        }
        [TestMethod]
        public void TestThatCardListCorrectThreeItem()
        {
            cardList = new List<SQADemicApp.GameBoardModels.Card>();
            cardList.Add(new SQADemicApp.GameBoardModels.Card("test", SQADemicApp.GameBoardModels.CARDTYPE.Player, SQADemicApp.GameBoardModels.COLOR.blue));
            cardList.Add(new SQADemicApp.GameBoardModels.Card("test2", SQADemicApp.GameBoardModels.CARDTYPE.Player, SQADemicApp.GameBoardModels.COLOR.blue));
            cardList.Add(new SQADemicApp.GameBoardModels.Card("test3", SQADemicApp.GameBoardModels.CARDTYPE.Player, SQADemicApp.GameBoardModels.COLOR.blue));
            cardList.Add(new SQADemicApp.GameBoardModels.Card("Airlift", SQADemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQADemicApp.GameBoardModels.Card("One Quiet Night", SQADemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQADemicApp.GameBoardModels.Card("Resilient Population", SQADemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQADemicApp.GameBoardModels.Card("Government Grant", SQADemicApp.GameBoardModels.CARDTYPE.Special));
            cardList.Add(new SQADemicApp.GameBoardModels.Card("Forecast", SQADemicApp.GameBoardModels.CARDTYPE.Special));
            returnedList = createTestClass.makeCardList(new System.IO.StringReader("test; blue\ntest2; blue\ntest3; blue"));
            CollectionAssert.AreEqual(cardList, returnedList);
        }
        [TestMethod]
        public void TestThatGetsCorrectColorRed()
        {
            Assert.AreEqual(SQADemicApp.GameBoardModels.COLOR.red, HelperBL.getColor("red"));
        }
        [TestMethod]
        public void TestThatGetsCorrectColorsRedBlue()
        {
            Assert.AreEqual(SQADemicApp.GameBoardModels.COLOR.red, HelperBL.getColor("red"));
            Assert.AreEqual(SQADemicApp.GameBoardModels.COLOR.blue, HelperBL.getColor("blue"));
        }
        [TestMethod]
        public void TestThatGetsCorrectThreeColors()
        {
            Assert.AreEqual(SQADemicApp.GameBoardModels.COLOR.red, HelperBL.getColor("red"));
            Assert.AreEqual(SQADemicApp.GameBoardModels.COLOR.blue, HelperBL.getColor("blue"));
            Assert.AreEqual(SQADemicApp.GameBoardModels.COLOR.black, HelperBL.getColor("black"));
        }
        [TestMethod]
        public void TestThatGetsCorrectAllColors()
        {
            Assert.AreEqual(SQADemicApp.GameBoardModels.COLOR.red, HelperBL.getColor("red"));
            Assert.AreEqual(SQADemicApp.GameBoardModels.COLOR.blue, HelperBL.getColor("blue"));
            Assert.AreEqual(SQADemicApp.GameBoardModels.COLOR.black, HelperBL.getColor("black"));
            Assert.AreEqual(SQADemicApp.GameBoardModels.COLOR.yellow, HelperBL.getColor("yellow"));
        }
    }
}
