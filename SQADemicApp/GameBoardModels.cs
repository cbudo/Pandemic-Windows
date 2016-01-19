using SQADemicApp.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        public static List<Cards> EventCards;
        public static LinkedList<string> InfectionDeck;
        public static LinkedList<string> InfectionPile;
        public static int InfectionRate;
        public static int InfectionRateIndex;
        public static DifficultySetting Difficulty = DifficultySetting.Medium;

        #endregion Public Static Vars

        #region Public Vars

        public int CurrentPlayerTurnCounter;

        #endregion Public Vars

        #region private vars

        private static bool _alreadySetUp = false;
        public static Stack<Cards> PlayerDeck;

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
                Cards[] playerDeckArray;
                List<string> infectionDeckList;
                Create.SetUpCreate(playersroles, out playerDeckArray, out infectionDeckList);
                PlayerDeck = new Stack<Cards>(playerDeckArray);
                EventCards = new List<Cards>();
                InfectionPile = new LinkedList<string>();
                InfectionDeck = new LinkedList<string>(Create.MakeInfectionDeck(new StringReader(SQADemicApp.Properties.Resources.InfectionDeck)));
            }

            //Players setup allows existing players to be overwritten
            Players = new Player[playersroles.Length];
            CurrentPlayerTurnCounter = 0;
            CurrentPlayerIndex = 0;
            for (int i = 0; i < playersroles.Count(); i++)
            {
                switch (playersroles[i])
                {
                    case "Dispatcher":
                        Players[i] = new Player(Role.Dispatcher);
                        break;

                    case "Operations Expert":
                        Players[i] = new Player(Role.OpExpert);
                        break;

                    case "Scientist":
                        Players[i] = new Player(Role.Scientist);
                        break;

                    case "Medic":
                        Players[i] = new Player(Role.Medic);
                        break;

                    case "Researcher":
                        Players[i] = new Player(Role.Researcher);
                        break;

                    default:
                        Players[i] = null;
                        break;
                }
            }
            if (Difficulty == DifficultySetting.Hard) {
                InfectionRate = 3;
            } else {
                InfectionRate = 2;
            }
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
            String specials = "Airlift One Quiet Night Resilient Population Government Grant Forecast";
            int cardsPerPlayer = Players.Count() == 4 ? 2 : Players.Count() == 3 ? 3 : 4;
            foreach (Player player in Players)
            {
                for (int i = 0; i < cardsPerPlayer; i++)
                {
                    Cards card = DrawCard();
                    if (card.CityName.Equals("EPIDEMIC"))
                    {
                        string infectcityname = InfectorBl.Epidemic(GameBoardModels.InfectionDeck, GameBoardModels.InfectionPile, ref GameBoardModels.InfectionRateIndex, ref GameBoardModels.InfectionRate);
                        new PicForm(false, infectcityname).Show();
                        for (int j = 0; j < 3; j++)
                        {
                            InfectorBl.InfectCities(new List<string> { infectcityname });
                        }
                    }
                    else if (specials.Contains(card.CityName))
                        EventCards.Add(card);
                    else
                        player.Hand.Add(card);
                }
            }
        }

        public bool IncTurnCount()
        {
            if (CurrentPlayerTurnCounter == 3)
            {
                //CurrentPlayerIndex = (CurrentPlayerIndex + 1) % players.Count();
                CurrentPlayerTurnCounter = 0;
                return true;
            }
            else
                CurrentPlayerTurnCounter++;
            return false;

            //currentPlayerTurnCounter++;
        }

        public static Cards DrawCard()
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

        public class Cures
        {
            public enum Curestate { NotCured, Cured, Sunset }

            public Curestate RedCure { get; set; }
            public Curestate BlueCure { get; set; }
            public Curestate BlackCure { get; set; }
            public Curestate YellowCure { get; set; }

            public Curestate GetCureStatus(Color color)
            {
                switch (color)
                {
                    case Color.Red:
                        return RedCure;

                    case Color.Blue:
                        return BlueCure;

                    case Color.Yellow:
                        return YellowCure;

                    case Color.Black:
                        return BlackCure;

                    default:
                        throw new ArgumentException("Not a vaild color");
                }
            }

            public void SetCureStatus(Color color, Curestate curestate)
            {
                switch (color)
                {
                    case Color.Red:
                        RedCure = curestate;
                        break;

                    case Color.Blue:
                        BlueCure = curestate;
                        break;

                    case Color.Yellow:
                        YellowCure = curestate;
                        break;

                    case Color.Black:
                        BlackCure = curestate;
                        break;

                    default:
                        throw new ArgumentException("Not a vaild color");
                }
            }
        }

        #endregion Storage Classes
    }
}