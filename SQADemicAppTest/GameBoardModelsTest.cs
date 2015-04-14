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
            cardList.Add(new SQAdemicApp.GameBoardModels.Card("test", SQAdemicApp.GameBoardModels.CARDTYPE.Player, SQAdemicApp.GameBoardModels.COLOR.blue));
            returnedList = createTestClass.makeCardList(new System.IO.StringReader("test; blue"));
            Assert.IsTrue(cardList[0].Equals(returnedList[0]));
        }
        [TestMethod]
        public void TestThatCardListCorrectTwoItem()
        {
            cardList.Add(new SQAdemicApp.GameBoardModels.Card("test", SQAdemicApp.GameBoardModels.CARDTYPE.Player, SQAdemicApp.GameBoardModels.COLOR.blue));
            cardList.Add(new SQAdemicApp.GameBoardModels.Card("test2", SQAdemicApp.GameBoardModels.CARDTYPE.Player, SQAdemicApp.GameBoardModels.COLOR.blue));
            returnedList = createTestClass.makeCardList(new System.IO.StringReader("test; blue\ntest2; blue"));
            CollectionAssert.AreEqual(cardList, returnedList);
        }
    }
}
