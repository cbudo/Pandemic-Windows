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
        #region Constansts
        private const int TWO_PLAYER_HAND = 4;
        private const int THREE_PLAYER_HAND = 3;
        private const int FOUR_PLAYER_HAND = 2;
        #endregion Constants

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
        private PlayerDeck playerDeck;

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

                // deprecated
                Card[] playerDeckArray;

                List<string> infectionDeckList;
                Create.SetUpCreate(playersroles, out playerDeckArray, out infectionDeckList);

                // deprecated
                PlayerDeck = new Stack<Card>(playerDeckArray);

                playerDeck = new PlayerDeck(Difficulty, Players.Count());
                playerDeck.init();
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
            List<Card> cardsToBeDealt = playerDeck.getInitialDeal();
            foreach (Player player in Players)
            {
                for (int i = 0; i < cardsToBeDealt.Count(); i++)
                {
                    Card card = cardsToBeDealt.ElementAt(i);
                    if (card.CardType == Card.Cardtype.Special)
                        EventCards.Add(card);
                    else
                        player.Hand.Add(card);
                }
            }
        }
        
        public Card DrawCard()
        {
            try
            {
                return playerDeck.draw();
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