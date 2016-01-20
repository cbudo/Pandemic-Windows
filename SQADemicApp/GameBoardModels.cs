using SQADemicApp.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQADemicApp.Players;

namespace SQADemicApp
{
    public enum Color { Red, Black, Blue, Yellow }
    public enum DifficultySetting { Easy, Medium, Hard, Legendary }

    public class GameBoardModels
    {
        #region Public Static Vars

        public static InfectionCubeCount CubeCount;
        public static Cures Curestatus;
        public static List<string> CitiesWithResearchStations;
        public static int OutbreakMarker = 0;
        public static Player[] Players;
        public static int CurrentPlayerIndex;
        public static List<Card> EventCards;
        public static LinkedList<string> InfectionDeck;
        public static LinkedList<string> InfectionPile;
        public static int InfectionRate;
        public static int InfectionRateIndex;
        public static DifficultySetting Difficulty = DifficultySetting.Medium;

        #endregion Public Static Vars
        

        #region private vars

        private static bool _alreadySetUp = false;
        public static Stack<Card> PlayerDeck;

        #endregion private vars

        /// <summary>
        /// Acts as a Main function. Sets up the game and the board state
        /// </summary>
        /// <param name="playersroles"></param>
        public GameBoardModels(string[] playersroles)
        {
            //Keep from making duplicates
            if (!_alreadySetUp)
            {
                //set vars
                OutbreakMarker = 0;
                CubeCount = new InfectionCubeCount();
                CubeCount.BlackCubes = CubeCount.RedCubes = CubeCount.BlueCubes = CubeCount.YellowCubes = 24;
                Curestatus = new Cures();
                Curestatus.BlackCure = Curestatus.BlueCure = Curestatus.RedCure = Curestatus.YellowCure = Cures.Curestate.NotCured;
                Card[] playerDeckArray;
                List<string> infectionDeckList;
                Create.SetUpCreate(playersroles, out playerDeckArray, out infectionDeckList);
                PlayerDeck = new Stack<Card>(playerDeckArray);
                EventCards = new List<Card>();
                InfectionPile = new LinkedList<string>();
                InfectionDeck = new LinkedList<string>(Create.MakeInfectionDeck(new StringReader(Properties.Resources.InfectionDeck)));
            }

            //Players setup allows existing players to be overwritten
            Players = new Player[playersroles.Length];
            CurrentPlayerIndex = 0;
            PlayerFactory.init(playersroles);
            InfectionRate = Difficulty == DifficultySetting.Hard ? 3 : 2;
            InfectionRateIndex = 0;
            if (!_alreadySetUp)
            {
                StartGameInfection();
                SetUpPlayerHands();
            }

            _alreadySetUp = true;
        }

        private void StartGameInfection()
        {
            for (int i = 3; i > 0; i--)
            {
                List<string> infectedcites = InfectorBl.InfectCities(InfectionDeck, InfectionPile, 3);
                for (int j = 0; j < i; j++)
                {
                    InfectorBl.InfectCities(infectedcites);
                }
            }
        }

        private void SetUpPlayerHands()
        {
            int cardsPerPlayer = Players.Count() == 4 ? 2 : Players.Count() == 3 ? 3 : 4;
            foreach (Player player in Players)
            {
                for (int i = 0; i < cardsPerPlayer; i++)
                {
                    Card card = DrawCard();
                    if (card.CardType.Equals(Card.Cardtype.Epidemic))
                    {
                        string infectcityname = InfectorBl.Epidemic(GameBoardModels.InfectionDeck, GameBoardModels.InfectionPile, ref GameBoardModels.InfectionRateIndex, ref GameBoardModels.InfectionRate);
                        new PicForm(false, infectcityname).Show();
                        for (int j = 0; j < 3; j++)
                        {
                            InfectorBl.InfectCities(new List<string> { infectcityname });
                        }
                    }
                    else if (card.CardType == Card.Cardtype.Special)
                        EventCards.Add(card);
                    else
                        player.Hand.Add(card);
                }
            }
        }
        
        public static Card DrawCard()
        {
            try
            {
                return PlayerDeck.Pop();
            }
            catch (InvalidOperationException e)
            {
                throw new Exception("Game Over");
            }
        }

        public int PlayerDeckSize()
        {
            return PlayerDeck.Count();
        }

        #region Storage Classes

        public class InfectionCubeCount
        {
            public int RedCubes { get; set; }
            public int BlackCubes { get; set; }
            public int BlueCubes { get; set; }
            public int YellowCubes { get; set; }
        }

        

        #endregion Storage Classes
    }
}