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
        //public static Dictionary<Color, Cures.CureState> descDict = new Dictionary<string, string>();
        public static List<string> CitiesWithResearchStations;
        public static int OutbreakMarker = 0;
        public static Player[] Players;
        public static int CurrentPlayerIndex;
        public static List<Cards> EventCards;
        public static LinkedList<string> InfectionDeck;
        public static LinkedList<string> InfectionPile;
        public static int InfectionRate;
        public static int InfectionRateIndex;
        public static DifficultySetting Difficulty = DifficultySetting.Medium;

        #endregion Public Static Vars

        #region private vars

        private static bool _alreadySetUp = false;
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

                List<string> infectionDeckList;
                Create.SetUpCreate(playersroles, out infectionDeckList);

                playerDeck = new PlayerDeck(Difficulty, playersroles.Length);
                EventCards = new List<Cards>();
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
            List<Cards> cardsToBeDealt = playerDeck.getInitialDeal();
            foreach (Player player in Players)
            {
                for (int i = 0; i < cardsToBeDealt.Count(); i++)
                {
                    Cards card = cardsToBeDealt.ElementAt(i);
                    if (card.GetType() == typeof(SpecialCard))
                    {
                        EventCards.Add(card);
                    }
                    else
                    {
                        System.Console.WriteLine("card : " + card + " " + player.Hand);
                        player.Hand.Add(card);
                    }
                }
            }
        }
        
        public Cards DrawCard()
        {
            return playerDeck.draw();
        }

        public int PlayerDeckSize()
        {
            return playerDeck.getDeckSize();
        }

        #region Storage Classes

        public class InfectionCubeCount
        {
            public int RedCubes { get; set; }
            public int BlackCubes { get; set; }
            public int BlueCubes { get; set; }
            public int YellowCubes { get; set; }

            public int GetColorCubeCount(Color color)
            {
                Dictionary<Color, int> allcubes = new Dictionary<Color, int>();
                allcubes.Add(Color.Blue, BlueCubes);
                allcubes.Add(Color.Black, BlackCubes);
                allcubes.Add(Color.Red, RedCubes);
                allcubes.Add(Color.Yellow, YellowCubes);
                return allcubes[color];
            }

            public void setCubeCount(Color color, int newCount)
            {
                switch (color)
                {
                    case Color.Red:
                        RedCubes = newCount;
                        break;

                    case Color.Blue:
                        BlueCubes = newCount;
                        break;

                    case Color.Yellow:
                        YellowCubes = newCount;
                        break;

                    case Color.Black:
                        BlackCubes = newCount;
                        break;

                    default:
                        throw new ArgumentException("invalid color");
                }
            }
        }

        

        #endregion Storage Classes
    }
}