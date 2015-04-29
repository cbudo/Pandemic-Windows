using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SQADemicApp.BL;
using SQADemicApp;

namespace SQADemicAppTest
{
    [TestClass]
    public class GameBoardModelsTest
    {
        List<Card> returnedList = new List<Card>();
        List<Card> cardList = new List<Card>();
        SQADemicApp.Create createTestClass = new SQADemicApp.Create();
        #region cardList
        [TestMethod]
        public void TestThatCardListCorrectOneItem()
        {
            cardList = new List<Card>();
            cardList.Add(new Card("test", Card.CARDTYPE.City, COLOR.blue));
            cardList.Add(new Card("Airlift", Card.CARDTYPE.Special));
            cardList.Add(new Card("One Quiet Night", Card.CARDTYPE.Special));
            cardList.Add(new Card("Resilient Population", Card.CARDTYPE.Special));
            cardList.Add(new Card("Government Grant", Card.CARDTYPE.Special));
            cardList.Add(new Card("Forecast", Card.CARDTYPE.Special));
            returnedList = createTestClass.makeCardList(new System.IO.StringReader("test; blue"));
            Assert.IsTrue(cardList[0].Equals(returnedList[0]));
        }
        [TestMethod]
        public void TestThatCardListCorrectTwoItem()
        {
            cardList = new List<Card>();
            cardList.Add(new Card("test", Card.CARDTYPE.City, COLOR.blue));
            cardList.Add(new Card("test2", Card.CARDTYPE.City, COLOR.blue));
            cardList.Add(new Card("Airlift", Card.CARDTYPE.Special));
            cardList.Add(new Card("One Quiet Night", Card.CARDTYPE.Special));
            cardList.Add(new Card("Resilient Population", Card.CARDTYPE.Special));
            cardList.Add(new Card("Government Grant", Card.CARDTYPE.Special));
            cardList.Add(new Card("Forecast", Card.CARDTYPE.Special));
            returnedList = createTestClass.makeCardList(new System.IO.StringReader("test; blue\ntest2; blue"));
            CollectionAssert.AreEqual(cardList, returnedList);
        }
        [TestMethod]
        public void TestThatCardListCorrectThreeItem()
        {
            cardList = new List<Card>();
            cardList.Add(new Card("test", Card.CARDTYPE.City, COLOR.blue));
            cardList.Add(new Card("test2", Card.CARDTYPE.City, COLOR.blue));
            cardList.Add(new Card("test3", Card.CARDTYPE.City, COLOR.blue));
            cardList.Add(new Card("Airlift", Card.CARDTYPE.Special));
            cardList.Add(new Card("One Quiet Night", Card.CARDTYPE.Special));
            cardList.Add(new Card("Resilient Population", Card.CARDTYPE.Special));
            cardList.Add(new Card("Government Grant", Card.CARDTYPE.Special));
            cardList.Add(new Card("Forecast", Card.CARDTYPE.Special));
            returnedList = createTestClass.makeCardList(new System.IO.StringReader("test; blue\ntest2; blue\ntest3; blue"));
            CollectionAssert.AreEqual(cardList, returnedList);
        }
#endregion
        #region testColor
        [TestMethod]
        public void TestThatGetsCorrectColorRed()
        {
            Assert.AreEqual(COLOR.red, HelperBL.getColor("red"));
        }
        [TestMethod]
        public void TestThatGetsCorrectColorsRedBlue()
        {
            Assert.AreEqual(COLOR.red, HelperBL.getColor("red"));
            Assert.AreEqual(COLOR.blue, HelperBL.getColor("blue"));
        }
        [TestMethod]
        public void TestThatGetsCorrectThreeColors()
        {
            Assert.AreEqual(COLOR.red, HelperBL.getColor("red"));
            Assert.AreEqual(COLOR.blue, HelperBL.getColor("blue"));
            Assert.AreEqual(COLOR.black, HelperBL.getColor("black"));
        }
        [TestMethod]
        public void TestThatGetsCorrectAllColors()
        {
            Assert.AreEqual(COLOR.red, HelperBL.getColor("red"));
            Assert.AreEqual(COLOR.blue, HelperBL.getColor("blue"));
            Assert.AreEqual(COLOR.black, HelperBL.getColor("black"));
            Assert.AreEqual(COLOR.yellow, HelperBL.getColor("yellow"));
        }
        #endregion
        #region incrementPlayerTurn
        [TestMethod]
        public void TestThatPlayerTurnIncremented()
        {
            string[] players = {"Dispatcher","Scientist"};
            GameBoardModels model = new GameBoardModels(players);
            model.incTurnCount();
            Assert.AreEqual(2, model.currentPlayerTurnCounter);
        }
        #endregion
        #region nextPlayer

        #endregion
    }
}
